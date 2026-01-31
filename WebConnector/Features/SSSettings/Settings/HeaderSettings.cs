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

    /**
     * Set your HeaderSettings
     *  <param name="id">SSSettings id (You must be a different id. if you're using the same id, <b>the plugin will be sent error</b>).</param>
     *  <param name="name">Set the HeaderSettings name.</param>
     *  <param name="hint">Set your hint object (Can be Null)</param>
     *  <param name="padding">Set headerSettings padding (the default is 'true')</param>
     *  <returns>It makes HeaderSettings and save to HeaderList</returns>
     */
    public static void SetHeader(int id, string name, string hint = null, bool padding = true)
    {
        try
        {
            HeaderSetting = new HeaderSetting(id, name,  hint, padding);

            HeaderList.Add(HeaderSetting);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    /**It Registers the target player's HeaderSettings and sends to the target player
     * <param name="player">Set a target player</param>
     * <returns>Register HeaderSettings to target player, and sent to target player</returns>
     */
    public static void RegisterHeaderSettings(Player player)
    {
        try
        {
            SettingBase.Register(player, HeaderList);
            SettingBase.SendToPlayer(player);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    /**It Registers HeaderSettings And apply this data Globally.
     * <returns>Register saved HeaderList data. And sent Globally.</returns>
     */
    public static void RegisterHeaderSettings()
    {
        try
        {
            SettingBase.Register(HeaderList);
            SettingBase.SendToAll();
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

}