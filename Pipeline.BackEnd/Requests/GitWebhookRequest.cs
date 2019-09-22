using Pipeline.Shared.Entities.Repositories.DTO.Git;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pipeline.BackEnd.Requests
{
    public class GitWebhookRequest : IRequest<bool>
    {
        public GitWebhook Webhook { get; set; }
    }
}
