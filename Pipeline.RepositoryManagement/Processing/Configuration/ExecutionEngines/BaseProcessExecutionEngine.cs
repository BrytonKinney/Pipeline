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
        public abstract Process GetProcess(CommandType commandType, string processPath, string workingDirectoryPath, params string[] arguments);
        public EventHandler<PipeEvents.EventArgs.ProcessOutputEventArgs> OnProcessOutputReceived { get; set; }
        public EventHandler<PipeEvents.EventArgs.ProcessExitedEventArgs> OnExit { get; set; }

        public async Task ExecuteCommandAsync(Command command)
        {
            var output = new StringBuilder(4096 * 10);
            var cmdType = command.Type == Constants.Serialization.CommandTypes.Process ? CommandType.Process : CommandType.Shell;
            using (var proc = GetProcess(cmdType, command.ExecutionInstructions, command.WorkingDirectory, command.Arguments))
            {
                proc.OutputDataReceived += ProcessOutputDataReceived;
                proc.Exited += ProcessExited;
                proc.ErrorDataReceived += ProcessOutputDataReceived;
                proc.Start();
                if (cmdType == CommandType.Shell)
                {
                    using (var sr = proc.StandardOutput)
                    {
                        using (var sw = proc.StandardInput)
                        {

                            await sw.WriteLineAsync(string.Format("cd {0}", command.WorkingDirectory));
                            await sw.WriteLineAsync(command.ExecutionInstructions);
                            await sw.FlushAsync();
                            var stdout = await sr.ReadLineAsync();
                            System.Console.WriteLine(string.Format("Output received: {0}", stdout));
                            OnProcessOutputReceived?.Invoke(this, new PipeEvents.EventArgs.ProcessOutputEventArgs(stdout));
                        }

                    }
                }
                else
                {
                    proc.BeginOutputReadLine();
                    proc.WaitForExit();
                }
            }
        }
        private void ProcessExited(object sender, System.EventArgs eventArgs)
        {
            var proc = sender as System.Diagnostics.Process;
            OnExit?.Invoke(sender, new PipeEvents.EventArgs.ProcessExitedEventArgs(proc.ExitCode, proc.ExitTime));
        }
        private void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OnProcessOutputReceived?.Invoke(sender, new PipeEvents.EventArgs.ProcessOutputEventArgs(e.Data));
        }
    }
}
