using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using WebConnector.Features.Logger;

namespace WebConnector.Features.SSSettings.Settings;

public class ButtonSettings
{
    private static string Name => "ButtonSettings";
    // SSList
    private static List<ButtonSetting> ButtonList { get; } = [];
    internal static ButtonSetting  ButtonSetting { get; set; }

    /**
     * Set your SS Button Settings.
     * <param name="id">SSSettings id (You must be a different id. if you're using the same id, <b>the plugin will be sent error</b>).</param>
     * <param name="name">Button Title</param>
     * <param name="buttonText">Set Button inner text</param>
     * <param name="holdTime">Set the button hold time. (the default is 0.0f)</param>
     * <param name="action">Add Action if Invoke data. (You must set before add Action.)</param>
     * <param name="hint">Set your hint object (Can be null)</param>
     * <param name="header">Set your HeaderSetting object. (Can be null)</param>
     * <returns>Save this data to ButtonList</returns>
     */
    public static void Set(int id,
        string name, string buttonText, Action<Player, SettingBase> action, 
        string hint = null, HeaderSetting header = null, float holdTime = 0.0f)
    {
        try
        {
            ButtonSetting = new ButtonSetting(id, name, buttonText, holdTime, hint, header, action); 
            ButtonList.Add(ButtonSetting);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
    
    /**It Registers 'ButtonSettings' And applies this data to the target player.
     * <param name="player">Set to the target player</param>
     * <returns>Register saved buttonList data. And sent target player</returns>
     */
    public static void Register(Player player)
    {
        try
        {
            SettingBase.Register(player, ButtonList);
            SettingBase.SendToPlayer(player);
        }
        catch(Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
    
    /**It Registers ButtonSettings And apply this data Globally.
     * <returns>Register saved buttonList data. And sent Globally.</returns>
     */
    public static void Register()
    {
        try
        {
            SettingBase.Register(ButtonList);
            SettingBase.SendToAll();
        }
        catch(Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
}