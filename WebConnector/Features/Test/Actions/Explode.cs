using System;
using Exiled.API.Features.Core.UserSettings;
using Exiled.API.Features;

namespace WebConnector.Features.Test.Actions;

public class Explode
{
    public static Action<Player, SettingBase> Action { get; set; }

    private static void ExplodeWarhead()
    {
        Action = (p, s) =>
        {
            Exiled.API.Features.Cassie.Message("Warhead has been Activated", true);
            DeadmanSwitch.InitiateProtocol();
        };
    }
}