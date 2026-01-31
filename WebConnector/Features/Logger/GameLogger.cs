using System;
using System.Reflection;
using System.Text;
using Exiled.API.Features;

namespace WebConnector.Features.Logger;

public static class GameLogger
{
    private static bool IsErrorLogActive { get; set; } = true;
    private static bool IsInfoLogActive { get; set; } = true; 
    
    public static void Error(string _message, string messageSender = "Unknown")
    {
        try
        {
            if (!IsErrorLogActive) return;

            StringBuilder message = new StringBuilder();

            message.Append(
                $"[WebConnector.ERROR({messageSender})]: An Error detected. Error Description:\n {(string.IsNullOrEmpty(_message) ? "Unknown Error" : _message)}");
        
            Log.Error(message);
        }
        catch (Exception ex)
        {
            Log.Error($"[WebConnector.CRITICAL]: A Exception detected in logger system. the \"{MethodBase.GetCurrentMethod()?.Name} Logging system\" has been disabled." +
                      $"\n Description: {ex}");
            IsErrorLogActive = false;
        }
    }

    public static void Info(string _message, string messageSender = "Unknown")
    {
        try
        {
            if (!IsInfoLogActive) return;
            if (_message.Length is 0 or > 512)
            {
                throw new ArgumentException("You must set the length of _message between 0 and 512");
            }

            StringBuilder message = new StringBuilder(1, 512);

            message.Append(
                $"[WebConnector.INFO({messageSender})]: {_message}");

            Log.Info(message);
        }
        catch (Exception ex)
        {
            Log.Error($"[WebConnector.CRITICAL]: A Exception detected in logger system. the \"{MethodBase.GetCurrentMethod()?.Name} Logging system\" has been disabled." +
                      $"\n Description: {ex}");
            IsInfoLogActive = false;
        }
    }
}