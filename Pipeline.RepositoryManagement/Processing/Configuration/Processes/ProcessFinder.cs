namespace Pipeline.RepositoryManagement.Processing.Configuration.Processes
{
    public class ProcessFinder : IProcessFinder
    {
        private readonly RepositoryManagementConfiguration _pipelineConfiguration;
        public ProcessFinder(RepositoryManagementConfiguration pipelineConfiguration)
        {
            _pipelineConfiguration = pipelineConfiguration;
        }
        public System.Diagnostics.Process GetShell()
        {
            if (!string.IsNullOrWhiteSpace(_pipelineConfiguration.DefaultShellPath))
            {
                var shell = new System.Diagnostics.Process();
                shell.StartInfo = new System.Diagnostics.ProcessStartInfo(_pipelineConfiguration.DefaultShellPath)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true
                };
                return shell;
            }
            else
            {
                return new System.Diagnostics.Process();
            }
            // switch (System.Environment.OSVersion.Platform)
            // {
            //     case System.PlatformID.Unix:
            //         break;
            //     case System.PlatformID.Win32NT:
            //         break;
            //     default:
            //         break;
            // }
        }

        public System.Diagnostics.Process GetProcess(string processPath)
        {
            throw new System.NotImplementedException();
        }
    }
}