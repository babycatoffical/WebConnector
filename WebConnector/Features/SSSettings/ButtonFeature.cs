using System;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using WebConnector.Features.Logger;

namespace WebConnector.Features.SSSettings;

public class ButtonFeature
{
    private static MainLogger _logger = new();
    
    private static int _id;
    private static string _name;
    private static string _hintDescription;

    private static int _mainId;
    private static string _label;
    private static string _buttonText;
    private static float _holdTime;
    private static string _hint;
    
    public ButtonFeature(int id, string name, string hintDescription, int mainId, string label, string buttonText, float holdTIme, string hint)
    {
        _id = id;
        _name = name;
        _hintDescription = hintDescription;

        _mainId = mainId;
        _label = label;
        _buttonText = buttonText;
        _holdTime = holdTIme;
        _hint = hint;
    }
    
    private static HeaderSetting HeaderSetting { get;} = new(_id, _name, _hintDescription);
    private static ButtonSetting ButtonSetting { get; } = new(_mainId, _label, _buttonText, _holdTime, _hint, HeaderSetting);
    
    
    public static void UpdateButtonSettings(string text, float holdTime)
    {
        ButtonSetting.UpdateSetting(text,  holdTime);
        
    }

    public void SendButtonToAllPlayer(Player player)
    {
        try
        {
            ButtonSetting.SendToPlayer(player);

        }
        catch (Exception ex)
        {
            Log.Error($"[WebConnector.ERR]: {ex}");
        }
    }

}