using System.Threading.Tasks;
namespace Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines
{
    public interface IExecutionEngine
    {
        Task ExecuteCommandAsync(Command command);
    }
}