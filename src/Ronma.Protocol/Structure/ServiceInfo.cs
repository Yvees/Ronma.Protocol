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
            Desc = string.Empty;
        }

        public ServiceInfo(BusChannel channel, string service, ServiceCommand[] commands, string desc)
        { 
            Channel = channel;
            Service = service;
            Commands = [.. commands];
            Desc = desc ?? string.Empty;
        }
        public BusChannel Channel { get; init; }

        public string Service {  get; init; }

        public string Desc { get; init; }

        public List<ServiceCommand> Commands { get; init; } = new List<ServiceCommand>();

        public override string ToString() => $"{Channel}.{Service}".ToLower();
    }
}
