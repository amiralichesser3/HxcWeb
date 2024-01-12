using MudBlazor;
using MudBlazor.Utilities;

public static class HxcUiThemeRepository
{
    public static MudTheme GetTheme()
    {
        return new MudTheme()
        {
            Palette = new PaletteLight()
                    {
                        Background = new MudColor("#EBEBEB"),
                        Primary = new MudColor("#7F4053"),
                        Secondary = new MudColor("#c02d76"),
                        Tertiary = new MudColor("#407F6C"),
                        Warning = new MudColor("#C5B0B5")
                    }
        };
    }
}
