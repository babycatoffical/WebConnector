using System.Collections.Generic;
using Exiled.API.Features.Core.UserSettings;

namespace WebConnector.Features.SSSettings.Settings;

public class Settings
{
    private static SliderSetting SliderSetting { get; set; }
    private static List<SliderSetting> SLiderList { get; set; } = [];
}