using Ronma.Protocol.Structure;

namespace Ronma.Protocol.Interface.Service
{
    public interface IService
    {
        ServiceInfo ServiceInfo { get; }
        Task Enroll();
        Task Unenroll();
    }
}
