using Microsoft.Extensions.Configuration;

namespace MagnanimousLyricsAndChords;

public partial class MainPage : ContentPage
{
    IConfiguration configuration;
    public MainPage(IConfiguration config)
	{
		InitializeComponent();
        configuration = config;
    }
}
