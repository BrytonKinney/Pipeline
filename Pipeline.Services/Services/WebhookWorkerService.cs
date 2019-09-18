using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pipeline.Services.Services
{
    public abstract class WebhookWorkerService : IWorkerService
    {
        public abstract Task AddWebhook<TWebook, THandler>(TWebook hook, THandler handler);
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
