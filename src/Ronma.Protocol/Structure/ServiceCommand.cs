namespace Ronma.Protocol.Structure
{
    public class ServiceCommand
    {
        public string Command { get; set; }

        public string Desc { get; set; }

        public ServiceCommand() { }

        public ServiceCommand(string command, string desc) { Command = command; Desc = desc; }
    }
}
