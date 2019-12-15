using System.IO;

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
                return GetProcess(_pipelineConfiguration.DefaultShellPath);
            else
            {
                switch (System.Environment.OSVersion.Platform)
                {
                    case System.PlatformID.Unix:
                        return GetProcess("/bin/bash");
                    case System.PlatformID.Win32NT:
                        return GetProcess(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System), "cmd.exe");
                    default:
                        throw new System.NotSupportedException("This platform is not supported. It may be possible to run this pipeline if the default shell path is specified in the pipeline configuration.");
                }
            }
        }

        public System.Diagnostics.Process GetProcess(string processPath, params string[] arguments)
        {
            var proc = new System.Diagnostics.Process();
            string args = arguments == null ? string.Join(' ', arguments) : string.Empty;
            proc.StartInfo = new System.Diagnostics.ProcessStartInfo(Path.GetFileName(processPath))
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                Arguments = args,
                WorkingDirectory = Path.GetDirectoryName(processPath)
            };
            return proc;
        }
    }
}