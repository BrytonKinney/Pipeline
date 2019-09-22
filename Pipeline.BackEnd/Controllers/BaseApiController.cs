using Pipeline.BackEnd.Handlers;
using Pipeline.BackEnd.Requests;
using Pipeline.Shared.Entities.Repositories.DTO.Git;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pipeline.BackEnd.Controllers
{
    public class BaseApiController : ApiController
    {
        public Task HandleRequest<IRequest, T>(IRequest request, System.Threading.CancellationToken cancellationToken = default)
        {
            var handler = new handler.Handler();
            handler
        }
    }
}