using Microsoft.Extensions.Hosting;
using RmqLibrary;
using System.Threading;
using System.Threading.Tasks;

namespace UserManagement.API
{
    internal class RmqHostedService : BackgroundService
    {
        private readonly IWorker _worker;

        public RmqHostedService(IWorker worker)
        {
            _worker = worker;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _worker.DoWork(stoppingToken);
            return Task.CompletedTask;
        }
    }
}