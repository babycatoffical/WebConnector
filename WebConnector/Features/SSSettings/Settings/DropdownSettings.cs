using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using UserSettings.ServerSpecific;
using WebConnector.Features.Logger;

namespace WebConnector.Features.SSSettings.Settings;

public class DropdownSettings
{
    private static string Name => "DropdownSettings";
    
    private static DropdownSetting DropDownSetting { get; set; }
    private static List<DropdownSetting> DropdownList { get; } = [];
    private static SSDropdownSetting.DropdownEntryType DropdownType { get; set; } =
        SSDropdownSetting.DropdownEntryType.Scrollable;
    
    /**
 * Set DropdownType
 * <param name="type">The type of SSDropdownSettings.DropdownEntryType</param>
 */
    public static void SetDropdownType(SSDropdownSetting.DropdownEntryType type)
    {
        try
        {
            DropdownType = type;
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    /**
     * Set your SS Dropdown Settings.
     * <param name="id">SSSettings id (You must be a different id. if you're using the same id, <b>the plugin will be sent error</b>).</param>
     * <param name="label">Dropdown Title</param>
     * <param name="settings">Your 'string' based Dropdown options.</param>
     * <param name="defaultIndexOptionIndex">Set default index.</param>
     * <param name="collectionId">Set collection ID. (between 0 ~ 255)</param>
     * <param name="hint">Set your hint object. (Can be null)</param>
     * <param name="header">Set your HeaderSetting object. (Can be null)</param>
     * <param name="action">Add Action if Invoke data. (You must set before add Action.)</param>
     */
    public static void Set(int id,
        string label, 
        IEnumerable<string> settings,
        int defaultIndexOptionIndex,
        byte collectionId,
        Action<Player, SettingBase> action,
        HeaderSetting header = null,
        string hint = null)
    {
        try
        {
            DropDownSetting = new DropdownSetting(
                id, label, settings,
                defaultIndexOptionIndex, DropdownType, hint,
                collectionId, false, header, action);
            DropdownList.Add(DropDownSetting);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    /**
     * It registers "DropdownSettings" And sends to the Target player
     * <param name="player">Target player</param>
     * <returns>Register the DropdownSettings. And sends this register to the target player.</returns>
     */
    public static void Register(Player player)
    {
        try
        {
            SettingBase.Register(player, DropdownList);
            SettingBase.SendToPlayer(player);
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }

    /**
 * It registers "DropdownSettings" And sends to Globally.
 * <returns>Register the DropdownSettings. And sends this register to Globally.</returns>
 */
    public static void Register()
    {
        try
        {
            SettingBase.Register(DropdownList);
            SettingBase.SendToAll();
        }
        catch (Exception ex)
        {
            GameLogger.Error($"{ex}", Name);
        }
    }
}