using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Services.Handlers
{
    public class WebhookHandler<T> : IWebhookHandler<T>
    {
        private T _webhook;
        public async Task Handle()
        {

        }
    }
}
