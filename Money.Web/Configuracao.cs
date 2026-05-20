using MudBlazor;
using static System.Net.WebRequestMethods;

namespace Money.Web
{
    public static class Configuracao
    {
        public const string HttpClientName = "money";
        public static string BackendUrl { get; set; } = "http://localhost:5001";

        public static MudTheme Tema = new()
        {
            Typography = new Typography()
            {
                Default = new Default()
                {
                    FontFamily = ["Raleway", "sans-serif"],
                }
            },
            Palette = new PaletteLight()
            {
                Primary = "#1EFA2D",
                Secondary = Colors.LightGreen.Darken3,
                Background = Colors.Green.Lighten4,
                AppbarBackground = "#1EFA2D",
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                PrimaryContrastText = Colors.Shades.Black,
                DrawerText = Colors.Shades.Black,
                DrawerBackground = Colors.Green.Lighten4,
            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.LightGreen.Darken3,
                Secondary = Colors.LightGreen.Darken3,
                AppbarBackground = Colors.LightGreen.Accent3,
                AppbarText = Colors.Shades.Black,
            }
        };
    }
}
