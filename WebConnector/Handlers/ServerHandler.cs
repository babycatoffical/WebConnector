using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using WebConnector.Features.SSSettings;


namespace WebConnector.Handlers;

public class ServerHandler
{
    public static void OnServerStarted(JoinedEventArgs ev)
    {
        Player player = ev.Player;

        ButtonFeature buttonFeature = new ButtonFeature(1, "엄준식", "점유율이 늘고, 접속자가 늘어", 1, "쌀다팜", "점유율이 늘고", 2.5f, "접속자가 늘어");
        player.PlayCassieAnnouncement("Activated");
        buttonFeature.SendButtonToAllPlayer(player);
    }
}