namespace Ronma.Protocol.Structure
{
    public class LlmResult
    {
        public bool Success { get; set; }

        public string Provider { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string Error { get; set; } = string.Empty;

        public string FinishReason { get; set; } = string.Empty;

        public int PromptTokens { get; set; }

        public int CompletionTokens { get; set; }

        public int TotalTokens { get; set; }

        public string Raw { get; set; } = string.Empty;
    }
}
