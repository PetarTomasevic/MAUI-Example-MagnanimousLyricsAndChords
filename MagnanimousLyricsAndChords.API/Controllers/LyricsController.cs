using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MagnanimousLyricsAndChords.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LyricsController : ControllerBase
    {
        public readonly IWebHostEnvironment _env;
        public LyricsController(IWebHostEnvironment env)
        {
            _env = env;
        }


        [HttpGet("search/{searchString}")]
        public async Task<ActionResult<List<string>>> SearchLyricsAsync(string  searchString)
        {
            List<string> searchResult =new List<string>();
            var options = new EnumerationOptions();
            options.RecurseSubdirectories = true;
            var root = $"{_env.ContentRootPath}\\Lyrics";
            var files = new DirectoryInfo(root).GetFiles("*", options);

            foreach (var file in files)
            {
                if(file.FullName.ToLower().Contains(searchString.ToLower())) { 
                searchResult.Add(file.Name);
                }
            }           

            return searchResult;


        }

        [HttpGet("get-chords/{name}")]
        public async Task<ActionResult<string>> GetChordsAsync(string name)
        {
            string searchResult = "";
            var options = new EnumerationOptions();
            options.RecurseSubdirectories = true;
            var root = $"{_env.ContentRootPath}\\Lyrics";
            var files = new DirectoryInfo(root).GetFiles("*", options);

            foreach (var file in files)
            {
                if (file.FullName.ToLower().Contains(name.ToLower()))
                {
                   
                    searchResult = System.IO.File.ReadAllText(file.FullName);
                }
            }

            return searchResult;


        }


    }
}
