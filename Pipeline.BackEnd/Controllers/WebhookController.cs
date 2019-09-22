using Pipeline.BackEnd.Handlers;
using Pipeline.BackEnd.Requests;
using Pipeline.Shared.Entities.Repositories.DTO.Git;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pipeline.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class WebhookController : BaseApiController
    {
        [HttpPost]
        [Route("gitHub")]
        public async Task<IHttpActionResult> ReceiveGitHook(GitWebhook gitEvent)
        {
            var resp = new WebhookHandler.Handler.Handle(new GitWebhookRequest { Webhook = gitEvent });
            return Content(System.Net.HttpStatusCode.OK, gitEvent);
        }
    }
}