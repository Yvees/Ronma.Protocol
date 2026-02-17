using Ronma.Protocol.Structure;

namespace Ronma.Protocol.Interface.Service
{
    public interface ILlmService : ICoreService
    {
        LlmEndpoint Endpoint { get; set; }

        Task<LlmResult> Perform(LlmContent content);
    }
}
