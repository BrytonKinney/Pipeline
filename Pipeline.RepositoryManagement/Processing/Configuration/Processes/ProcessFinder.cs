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
        public System.Diagnostics.Process GetShell(string workingDirectory)
        {
            if (!string.IsNullOrWhiteSpace(_pipelineConfiguration.DefaultShellPath))
                return GetProcess(_pipelineConfiguration.DefaultShellPath, workingDirectory);
            else
            {
                switch (System.Environment.OSVersion.Platform)
                {
                    case System.PlatformID.Unix:
                        return GetProcess("/bin/bash", workingDirectory);
                    case System.PlatformID.Win32NT:
                        return GetProcess(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System), "cmd.exe");
                    default:
                        throw new System.NotSupportedException("This platform is not supported. It may be possible to run this pipeline if the default shell path is specified in the pipeline configuration.");
                }
            }
        }

        public System.Diagnostics.Process GetProcess(string processPath, string workingDirectory, params string[] arguments)
        {
            var proc = new System.Diagnostics.Process() { EnableRaisingEvents = true };
            string args = arguments != null && arguments.Length > 0 ? string.Join(' ', arguments) : string.Empty;
            System.Console.WriteLine("Executing {0} with arguments: {1}", Path.GetFileName(processPath), args);
            proc.StartInfo = new System.Diagnostics.ProcessStartInfo(processPath)
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                Arguments = args,
                WorkingDirectory = workingDirectory
            };
            return proc;
        }
    }
}