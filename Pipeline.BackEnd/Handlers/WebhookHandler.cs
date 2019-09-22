using Pipeline.BackEnd.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pipeline.BackEnd.Handlers
{
    public static class WebhookHandler
    {
        public class Handler : IHandler<GitWebhookRequest, bool>
        {
            public Task<bool> Handle(GitWebhookRequest request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }
    }
}
