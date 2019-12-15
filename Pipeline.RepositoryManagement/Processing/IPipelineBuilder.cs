using System.Threading.Tasks;

namespace Pipeline.RepositoryManagement.Processing
{
    public interface IPipelineBuilder
    {
        Task<PipelineBuilder> BuildProject();
    }
}