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
    private static List<DropdownSetting> DropdownList { get; set; } = [];
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

    /** Set your DropdownSettings.
     * <param name="id">SSSettings id (You must be a different id. if you're using the same id, <b>the plugin will be sent error</b>).</param>
     * <param name="label">Dropdown Title</param>
     * <param name="settings">Your 'string' based Dropdown options.</param>
     * <param name="defaultIndexOptionIndex">Set default index.</param>
     * <param name="collectionId">Set collection ID. (between 0 ~ 255)</param>
     * <param name="hint">Set your hint object. (Can be null)</param>
     * <param name="header">Set your HeaderSetting object. (Can be null)</param>
     */
    public static void SetDropdown(int id,
        string label, IEnumerable<string> settings,
        int defaultIndexOptionIndex,
        byte collectionId,
        HeaderSetting header = null,
        string hint = null)
    {
        try
        {
            DropDownSetting = new DropdownSetting(id,
                label, settings, defaultIndexOptionIndex,
                DropdownType, hint, collectionId,
                false, header);
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
    public static void RegisterDropdownSettings(Player player)
    {
        SettingBase.Register(player, DropdownList);
        SettingBase.SendToPlayer(player);
    }

    /**
 * It registers "DropdownSettings" And sends to Globally.
 * <returns>Register the DropdownSettings. And sends this register to Globally.</returns>
 */
    public static void RegisterDropdownSettings()
    {
        SettingBase.Register(DropdownList);
        SettingBase.SendToAll();
    }
}