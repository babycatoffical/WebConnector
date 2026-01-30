using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using WebConnector.Features.Logger;

namespace WebConnector.Features.SSSettings.Settings;

public class ButtonSettings
{
    private static string Name => "SSSButtonFeature";
    // SSList
    private static List<ButtonSetting> _ButtonList { get; } = [];
    private static ButtonSetting  ButtonSetting { get; set; }

    public static void SetButton(int id, string name, string buttonText, string hint,  HeaderSetting header = null, float holdTime = 0.0f)
    {
        try
        {
            ButtonSetting = new ButtonSetting(id, name, buttonText, holdTime, hint, header); 
            _ButtonList.Add(ButtonSetting);

             GameLogger.Info("SetButton has been successfully completed.", Name);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
    
    /**Registers SSList systems at the target player.*/
    public static void RegisterButtonSettings(Player player)
    {
        try
        {
            SettingBase.Register(player, _ButtonList);

            GameLogger.Info($"Target Player: {player}'s Button Settings register has been completed.", Name);
        }
        catch(Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
    
    public static void RegisterButtonSettings()
    {
        try
        {
            SettingBase.Register(_ButtonList);
            SettingBase.SendToAll();

            GameLogger.Info("Globally Button Settings register has been completed.", Name);
        }
        catch(Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    public static void ApplyButtonSettings(Player player)
    {
        try
        {
            SettingBase.SendToPlayer(player);
            GameLogger.Info($"Target Player: {player}'s Button Settings has been completed.", Name);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
    
    public static void ApplyButtonSettings()
    {
        try
        {
            SettingBase.SendToAll();
            GameLogger.Info("Globally Button Settings has been completed.", Name);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
}