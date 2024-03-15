using System;
using Exiled.API.Features;
using CommandSystem;
using Exiled.API.Enums;
using MEC;
using System.Collections.Generic;

namespace LightOvercharge.Commands
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    internal sealed class Overcharge : ICommand
    {
        public string Command { get; } = "blackout";

        public string[] Aliases { get; } = { "blk" };

        public string Description { get; } = "Blackout selected zone(lz/hz/ez/srf)";  
        
        private Config config = new Config();

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            RoomType senderRoom = GetSenderLocation(sender);
            if(senderRoom == RoomType.EzIntercom)
            {
                string selectedZone = arguments.Array[1];

                ZoneType zone = SelectedBlackoutZone(selectedZone);
                BlackoutZone(zone, config.Duration);
                response = string.Empty;
                return true;
            }
            else
            {
                response = config.ErrorSenderLocation;
                return false;
            }
        }

        private void BlackoutZone(ZoneType zone, float duration)
        {
            Map.TurnOffAllLights(config.Duration, zone);
            Cassie.MessageTranslated("Light off", "Light off");
        }

        private RoomType GetSenderLocation(ICommandSender sender)
        {
            Player player = Player.Get(((CommandSender)sender).SenderId);
            Room senderRoom = player.CurrentRoom;
            return senderRoom.Type;
        }

        private ZoneType SelectedBlackoutZone(string selectedZone = "all")
        {
            ZoneType zone;
            switch (selectedZone)
            {
                case "lz":
                    zone = ZoneType.LightContainment;
                    break;
                case "hz":
                    zone = ZoneType.HeavyContainment;
                    break;
                case "ez":
                    zone = ZoneType.Entrance;
                    break;
                case "srf":
                    zone = ZoneType.Surface;
                    break;
                default:
                    throw new NullReferenceException(nameof(selectedZone));
            }

            return zone;
        }
    }
}
