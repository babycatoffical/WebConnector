using Exiled.API.Features;
using WebConnector.Handlers;
using Player =  Exiled.Events.Handlers.Player;

namespace WebConnector
{
    public class Plugin : Plugin<Config>
    {
        public Plugin Singleton { get; set; }
        
        public override string Name => "WebConnector";

        public override void OnEnabled()
        {
            Singleton = this;
            Log.Info($""" 
                        ======================[WebConnector.Info]======================
                        [WebConnector]: Successfully activated.
                        [WebConnector.Debug]: {Singleton.Config.Debug} 
                        [WebConnector.WebServerIP]: {(string.IsNullOrEmpty(Singleton.Config.IpAddress) ? "None" :  Singleton.Config.IpAddress)}
                        [WebConnector.DataType]: {Singleton.Config.DataSendType}
                        =============================[End]=============================
                     """);
            PluginRegister();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            
            PluginUnregister();
            base.OnDisabled();
        }

        private static void PluginRegister()
        {
            Player.Joined += ServerHandler.OnServerStarted;
        }

        private static void PluginUnregister()
        {
            Player.Joined -= ServerHandler.OnServerStarted;
        }
    }
}