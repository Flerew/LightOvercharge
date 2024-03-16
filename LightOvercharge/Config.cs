using Exiled.API.Interfaces;
using System;

namespace LightOvercharge
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        public float Duration { get; set; } = 15f;

        public string CassieMassage { get; set; } = "Facility has entered the emergency power mode";

        public string ErrorSenderLocation { get; set; } = "You must be in the intercom to use this command";
        public string ErrorArgumentsExeption { get; set; } = "You must select zone(lz/hz/ez/srf)";
    }
}
