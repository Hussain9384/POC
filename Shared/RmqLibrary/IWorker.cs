using System.Threading;
using System.Threading.Tasks;

namespace RmqLibrary
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}