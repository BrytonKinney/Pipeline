using Pipeline.RepositoryManagement.Constants;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines
{
    public abstract class BaseProcessExecutionEngine : IExecutionEngine
    {
        public abstract Process GetProcess(CommandType commandType, string processPath);
        public EventHandler<DataReceivedEventArgs> OutputDataReceived;
        public async Task ExecuteCommandAsync(Command command)
        {
            var output = new StringBuilder(4096 * 10);
            var cmdType = command.Type == Constants.Serialization.CommandTypes.Process ? CommandType.Process : CommandType.Shell;
            using (var proc = GetProcess(cmdType, command.ExecutionInstructions))
            {
                proc.OutputDataReceived += ProcessOutputDataReceived;
                proc.Start();
                if (cmdType == CommandType.Shell)
                {
                    using (var sr = proc.StandardOutput)
                    {
                        using (var sw = proc.StandardInput)
                        {
                            await sw.WriteLineAsync(command.ExecutionInstructions);
                            await sw.FlushAsync();
                        }
                        while (!sr.EndOfStream)
                        {
                            ProcessOutputDataReceived(this, new DataReceivedEventArgs(await sr.ReadLineAsync()));
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

        private void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutputDataReceived?.Invoke(sender, e);
        }
    }
}
