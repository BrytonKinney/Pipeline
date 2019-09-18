using Pipeline.Shared.Entities.Repositories.DTO.Git;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pipeline.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class WebhookController : ApiController
    {
        [HttpPost]
        [Route("gitHub")]
        public async Task<IHttpActionResult> ReceiveGitHook([FromBody] GitWebhook gitEvent)
        {
            return Content(System.Net.HttpStatusCode.OK, gitEvent);
        }
    }
}