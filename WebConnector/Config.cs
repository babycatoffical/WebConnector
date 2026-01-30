using Exiled.API.Interfaces;

namespace WebConnector
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public string DataSendType { get; set; } = "JSON";
        public string IpAddress { get; set; } = "";
    }
}