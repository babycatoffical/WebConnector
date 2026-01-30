using Exiled.Events.EventArgs.Player;
using WebConnector.Features.SSSettings;

namespace WebConnector.Handlers;

public class ServerHandler
{
    public static void OnJoined(JoinedEventArgs ev)
    {
        var target = ev.Player;
        
        SSMainSettings.RegisterSSSettings(target);
    }
    
}