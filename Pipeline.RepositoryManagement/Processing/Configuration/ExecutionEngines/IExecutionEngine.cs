using System;
using System.Threading.Tasks;
using PipeEvents = Pipeline.RepositoryManagement.Processing.Events;
namespace Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines
{
    public interface IExecutionEngine
    {
        EventHandler<PipeEvents.EventArgs.ProcessOutputEventArgs> OnProcessOutputReceived { get; }
        EventHandler<PipeEvents.EventArgs.ProcessExitedEventArgs> OnExit { get; }
        Task ExecuteCommandAsync(Command command);
    }
}