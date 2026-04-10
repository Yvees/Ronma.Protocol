namespace Ronma.Protocol.Structure
{
    public class LlmContent
    {
        public string Model { get; set; } = string.Empty;

        public bool Stream { get; set; }

        public string Prompt { get; set; } = string.Empty;

        public string ResponseSchemaName { get; set; } = string.Empty;

        public string ResponseSchema { get; set; } = string.Empty;

        public List<LlmContentPayload> Payloads { get; set; } = [];
    }
}
