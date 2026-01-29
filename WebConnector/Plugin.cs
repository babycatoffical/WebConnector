using Exiled.API.Features;
using WebConnector.Handlers;
using Player =  Exiled.Events.Handlers.Player;

namespace WebConnector
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton { get; set; }
        
        public override string Name => "WebConnector";

        public override void OnEnabled()
        {
            Singleton = this;
            
            PluginRegister();
            base.OnEnabled();
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