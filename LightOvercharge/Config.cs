using Exiled.API.Interfaces;
using System;

namespace LightOvercharge
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        public float Duration { get; set; } = 5f;

        public string ErrorSenderLocation { get; set; } = "You must be in the intercom to use this command";

        public bool isLightZoneLightsOn = true;
        public bool isHardZoneLightsOn = true;
        public bool isEntranceZoneLightsOn = true;
        public bool isSurfaceZoneLightsOn = true;
    }
}
