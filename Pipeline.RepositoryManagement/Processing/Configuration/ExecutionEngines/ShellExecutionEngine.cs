using System.Diagnostics;
using Pipeline.RepositoryManagement.Processing.Configuration.Processes;
using System.IO;
using System.Threading.Tasks;
namespace Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines
{
    public class ShellExecutionEngine : IExecutionEngine
    {
        private IProcessFinder _shellProcessFinder;
        public ShellExecutionEngine(IProcessFinder procFinder)
        {
            _shellProcessFinder = procFinder;
        }
        public async Task<string> ExecuteCommandAsync(Command command)
        {
            var output = new System.Text.StringBuilder(4096 * 10);
            using (var shell = _shellProcessFinder.GetShell())
            {
                shell.Start();
                using (var sr = shell.StandardOutput)
                {
                    using (var sw = shell.StandardInput)
                    {
                        await sw.WriteLineAsync(command.ExecutionInstructions);
                        await sw.FlushAsync();
                    }
                    while (!sr.EndOfStream)
                    {
                        output.Append(await sr.ReadLineAsync());
                    }
                }
            }
            return output.ToString();
        }
    }
}