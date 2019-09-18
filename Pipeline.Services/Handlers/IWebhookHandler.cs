using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Services.Handlers
{
    public interface IWebhookHandler<TWebhook>
    {
        Task Handle();
    }
}
