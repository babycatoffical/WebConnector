using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using WebConnector.Features.Logger;

namespace WebConnector.Features.SSSettings.Settings;

public class HeaderSettings
{
    private static string Name => "HeaderSettings"; 
    private static HeaderSetting  HeaderSetting { get; set; }
    private static List<HeaderSetting> HeaderList { get; } = [];
    
    public static void SetHeader(int id, string name, string hint, bool padding = true)
    {
        try
        {
            HeaderSetting = new HeaderSetting(id, name,  hint, padding);
            GameLogger.Info("SetHeader has been successfully completed.", Name);

            HeaderList.Add(HeaderSetting);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    public static void RegisterHeaderSettings(Player player)
    {
        try
        {
            SettingBase.Register(player, HeaderList);
            GameLogger.Info($"Target Player: {player}'s Header Settings register has been completed.", Name);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    public static void RegisterHeaderSettings()
    {
        try
        {
            SettingBase.Register(HeaderList);
            GameLogger.Info("Globally Header Settings register has been completed.", Name);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
    
    public static void ApplyHeaderSettings(Player player)
    {
        try
        {
            SettingBase.SendToPlayer(player);
            GameLogger.Info($"Target Player: {player}'s Header Settings apply has been completed.", Name);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
    
    public static void ApplyHeaderSettings()
    {
        try
        {
            SettingBase.SendToAll();
            GameLogger.Info($"Globally Header Settings apply has been completed.", Name);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
}