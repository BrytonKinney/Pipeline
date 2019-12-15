using System.IO;

namespace Pipeline.RepositoryManagement.Processing.Configuration.Processes
{
    public class ProcessFinder : IProcessFinder
    {
        private const string _bashPath = "/usr/bin/bash";
        private readonly RepositoryManagementConfiguration _pipelineConfiguration;
        public ProcessFinder(RepositoryManagementConfiguration pipelineConfiguration)
        {
            _pipelineConfiguration = pipelineConfiguration;
        }
        public System.Diagnostics.Process GetShell()
        {
            if (!string.IsNullOrWhiteSpace(_pipelineConfiguration.DefaultShellPath))
                return GetProcess(_pipelineConfiguration.DefaultShellPath);
            else
            {
                switch (System.Environment.OSVersion.Platform)
                {
                    case System.PlatformID.Unix:
                        return GetProcess(_bashPath);
                    case System.PlatformID.Win32NT:
                        return GetProcess(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System), "cmd.exe"));
                    default:
                        throw new System.NotSupportedException("This platform is not supported. It may be possible to run this pipeline if the default shell path is specified in the pipeline configuration.");
                }
            }
        }

        public System.Diagnostics.Process GetProcess(string processPath)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = new System.Diagnostics.ProcessStartInfo(processPath)
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            return proc;
        }
    }
}