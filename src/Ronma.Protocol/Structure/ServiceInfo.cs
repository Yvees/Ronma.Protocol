using Ronma.Protocol.Enums;

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

        public ServiceInfo(BusChannel channel, string service, string[] commands, string desc = "")
        { 
            Channel = channel;
            Service = service;
            Commands = [.. commands];
        }
        public BusChannel Channel { get; init; }

        public string Service {  get; init; }

        public string Desc { get; init; }

        public List<string> Commands { get; init; } = new List<string>();

        public override string ToString() => $"{Channel}.{Service}".ToLower();
    }
}
