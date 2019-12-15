using Pipeline.RepositoryManagement.Constants;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using PipeEvents = Pipeline.RepositoryManagement.Processing.Events;
namespace Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines
{
    public abstract class BaseProcessExecutionEngine : IExecutionEngine
    {
        public abstract Process GetProcess(CommandType commandType, string processPath);
        public EventHandler<PipeEvents.EventArgs.ProcessOutputEventArgs> ProcessOutputReceived;
        public async Task ExecuteCommandAsync(Command command)
        {
            var output = new StringBuilder(4096 * 10);
            var cmdType = command.Type == Constants.Serialization.CommandTypes.Process ? CommandType.Process : CommandType.Shell;
            using (var proc = GetProcess(cmdType, command.ExecutionInstructions))
            {
                proc.OutputDataReceived += ProcessOutputDataReceived;
                proc.Start();
                using (var sr = proc.StandardOutput)
                {
                    using (var sw = proc.StandardInput)
                    {
                        if (cmdType == CommandType.Shell)
                        {
                            await sw.WriteLineAsync(command.ExecutionInstructions);
                            await sw.FlushAsync();
                            ProcessOutputReceived?.Invoke(this, new PipeEvents.EventArgs.ProcessOutputEventArgs(await sr.ReadLineAsync()));
                        }
                        else
                        {
                            proc.BeginOutputReadLine();
                            proc.WaitForExit();
                        }
                    }
                }
            }
        }
        private void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            ProcessOutputReceived?.Invoke(sender, new PipeEvents.EventArgs.ProcessOutputEventArgs(e.Data));
        }
    }
}
