using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using WebConnector.SSSettings;

namespace WebConnector.Handlers;

public class ServerHandler
{
    public static void OnServerStarted(JoinedEventArgs ev)
    {
        Player player = ev.Player;
        
        ButtonTest.TestingButton();
    }
}