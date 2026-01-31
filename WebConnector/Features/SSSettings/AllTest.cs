using Exiled.API.Features;
using MEC;
using UnityEngine;
using WebConnector.Features.Logger;
using WebConnector.Features.SSSettings.Settings;

namespace WebConnector.Features.SSSettings;

public class AllTest
{
    public static void HeaderSet()
    {
        HeaderSettings.Set(1, "원자력 원격 제어장치", "그저 허름하게 생겼고 작동하지 않는 것 같은 원격 제어장치다.");
        HeaderSettings.Register();
    }
    
    public static void ButtonTest(Player player)
    {
        var header = HeaderSettings.GetHeaderData(1);
        var button = ButtonSettings.ButtonSetting;
        ButtonSettings.Set(2, "폭파 시퀸스 가동", "심영 폭⭐8 장치 작동", (_player, setting) =>
        {
            setting.IsServerOnly = false;
            AudioPlayer.Create("main");
            AudioPlayer.TryGet("main", out var audioPlayer);
            audioPlayer.AddSpeaker("main", new Vector3(39.26f, 314.353f, -32.471f) ,5f);
            Timing.CallDelayed(1.5f, Warhead.Detonate);

            GameLogger.Info("Triggered");
        }, "경고: 당신은 이 버튼을 누르고 있는 순간 천지를 뒤엎는 소리가 날 것이다.", header, 1.5f);
        ButtonSettings.Register(player);
    }
}