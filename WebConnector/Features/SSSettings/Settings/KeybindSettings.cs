using System;
using System.Collections.Generic;
using Exiled.API.Features;
using UnityEngine;
using Exiled.API.Features.Core.UserSettings;
using WebConnector.Features.Logger;

namespace WebConnector.Features.SSSettings.Settings;

public class KeybindSettings
{
    private static string Name => "KeybindSettings";
    internal static KeybindSetting KeybindSetting { get; set; }
    private static List<KeybindSetting> KeyBindList { get; } = [];

    /**
     * Set your Custom Keybind Settings.
     * <param name="id">SSSettings id (You must be a different id. if you're using the same id, <b>the plugin will be sent error</b>).</param>
     * <param name="label">Keybind label</param>
     * <param name="keycode">Your custom keycode. (you must set this.)</param>
     * <param name="collectionId">Set collection ID. (between 0 ~ 255)</param>
     * <param name="isGuiTrigger">The custom keycode click if active in GUI. (The default is false)</param>
     * <param name="hint">Set your hint object. (Can be null)</param>
     * <param name="header">Set your HeaderSetting object. (Can be null)</param>
     * <param name="action">Add Action if Invoke data. (You must set before add Action.)</param>
     * <param name="isObserverTrigger">The custom keycode click if active in Observer mode. (The default is false)</param>
     */
    public static void Set(
        int id, string label, KeyCode keycode,  
        string hint, byte collectionId, HeaderSetting header,
        Action<Player, SettingBase> action, bool isGuiTrigger = false, bool isObserverTrigger = false)
    {
        try
        {
            KeybindSetting = new KeybindSetting(
                id, label, keycode,
                isGuiTrigger, isObserverTrigger, hint,
                collectionId, header, action);
            KeyBindList.Add(KeybindSetting);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    /**It Registers the target player's KeycodeSettings and sends to the target player.
     * <param name="player">Set a target player</param>
     * <returns>Register KeycodeSettings to target player, and sent to target player</returns>
     */
    public static void Set(Player player)
    {
        try
        {
            SettingBase.Register(player, KeyBindList);
            SettingBase.SendToPlayer(player);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    /**It Registers KeycodeSettings And apply this data Globally.
     * <returns>Register saved KeyBindList data. And sent Globally.</returns>
     */
    public static void Set()
    {
        try
        {
            SettingBase.Register(KeyBindList);
            SettingBase.SendToAll();
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
}