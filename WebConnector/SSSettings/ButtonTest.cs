using Exiled.API.Features.Core.UserSettings;

namespace WebConnector.SSSettings;

public class ButtonTest
{
    private static HeaderSetting _headerSetting { get;} = new(1, "123", "123");
    private static ButtonSetting buttonSetting { get; } = new(1, "123", "123", 2.5f, "123", _headerSetting);
    
    public static void TestingButton()
    {
        buttonSetting.UpdateSetting("Hello, World!", 2.5f);

    } 
}