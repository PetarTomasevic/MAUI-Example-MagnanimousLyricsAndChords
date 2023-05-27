using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDirectoryBrowser();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials


app.UseFileServer(
        new FileServerOptions
        {
            FileProvider=new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath,"Lyrics")),
            RequestPath="/Lyrics",
            EnableDirectoryBrowsing=false        
        }
    );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
