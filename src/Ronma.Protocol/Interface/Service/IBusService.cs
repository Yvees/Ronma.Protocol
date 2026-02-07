using Ronma.Protocol.Structure;

namespace Ronma.Protocol.Interface.Service
{
    public interface IBusService : ICoreService
    {
        Task PublishAsync(ServiceInfo info, Packet packet);

        Task<bool> SubscribeAsync(ServiceInfo info, Func<Packet, Task<bool>> processor);
    }
}
