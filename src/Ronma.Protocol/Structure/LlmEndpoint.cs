using Ronma.Protocol.Enums;

namespace Ronma.Protocol.Structure
{
    public class LlmEndpoint
    {
        public string Uri { get; set; } = string.Empty;

        public LlmProvider Provider { get; set; } = LlmProvider.Ollama;

        public string DefaultModel { get; set; } = string.Empty;

        public string ApiKey { get; set; } = string.Empty;
    }
}
