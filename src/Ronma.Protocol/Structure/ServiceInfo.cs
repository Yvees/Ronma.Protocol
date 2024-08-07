﻿using Ronma.Protocol.Enums;

namespace Ronma.Protocol.Structure
{
    public record ServiceInfo
    {
        public ServiceInfo()
        {

        }
        public ServiceInfo(BusChannel channel, string service)
        {
            Channel = channel;
            Service = service;
        }

        public ServiceInfo(BusChannel channel, string service, string command, string desc)
        { 
            Channel = channel;
            Service = service;
            Command = command;
            Desc = desc;
        }
        public BusChannel Channel { get; init; }

        public string Service {  get; init; }

        public string Command { get; init; }

        public string Desc { get; init; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Command))
                return $"{Channel}.{Service}".ToLower();
            else
                return $"{Channel}.{Service}.{Command}".ToLower();
        }
    }
}
