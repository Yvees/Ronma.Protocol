namespace Ronma.Protocol.Structure
{
    public class LlmResponse
    {
        public string Provider { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public bool Done { get; set; }

        public string FinishReason { get; set; } = string.Empty;

        public int PromptTokens { get; set; }

        public int CompletionTokens { get; set; }

        public int TotalTokens { get; set; }

        public long TotalDuration { get; set; }

        public long LoadDuration { get; set; }

        public long PromptEvalDuration { get; set; }

        public long EvalDuration { get; set; }

        public string Raw { get; set; } = string.Empty;
    }
}
