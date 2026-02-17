using Ronma.Protocol.Enums;

namespace Ronma.Protocol.Structure
{
    public class LlmContentPayload
    {
        public LlmContentPayload(LlmContentPayloadType type, byte[] content)
        {
            Type = type;
            Content = content;
        }


        public LlmContentPayloadType Type { get; set; }

        public byte[] Content { get; set; }
    }
}
