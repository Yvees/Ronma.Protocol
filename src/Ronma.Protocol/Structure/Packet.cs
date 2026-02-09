using System;

namespace Ronma.Protocol.Structure
{
    public class Packet
    {
        public Packet()
        {
        }

        public Packet(string service, string command, List<byte[]> args)
        {
            Service = service;
            Command = command;
            Args = args;
        }

        public Packet(string service, string command, string sender, List<byte[]> args)
        {
            Service = service;
            Command = command;
            Sender = sender;
            Args = args;
        }

        public string Service { get; set; }

        public string Command { get; set; }

        public string Sender { get; set; }

        public string TraceId { get; set; } = CreateTraceId();

        public List<byte[]> Args { get; set; }

        private static string CreateTraceId()
        {
            var guid = Guid.CreateVersion7();
            return Convert.ToBase64String(guid.ToByteArray())
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');
        }
    }
}
