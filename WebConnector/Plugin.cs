using Exiled.API.Features;
using WebConnector.Handlers;
using Player =  Exiled.Events.Handlers.Player;

namespace WebConnector
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; set; }
        
        public override string Name => "WebConnector";

        public override void OnEnabled()
        {
            Instance = this;
            Log.Info("\n" + $""" 
                         ======================[WebConnector.Info]======================
                         [WebConnector]: Successfully activated.
                         [WebConnector.Debug]: {Instance.Config.Debug} 
                         [WebConnector.WebServerIP]: {(string.IsNullOrEmpty(Instance.Config.IpAddress) ? "None" :  Instance.Config.IpAddress)}
                         [WebConnector.DataType]: {Instance.Config.DataSendType}
                         =============================[End]=============================
                      """);
            
            PluginRegister();
        }

        public override void OnDisabled()
        {
            Instance = null;
            
            PluginUnregister();
            base.OnDisabled();
        }

        private static void PluginRegister()
        {
            Player.Joined += ServerHandler.OnJoined;
        }

        private static void PluginUnregister()
        {
            Player.Joined -= ServerHandler.OnJoined;
        }
    }
}