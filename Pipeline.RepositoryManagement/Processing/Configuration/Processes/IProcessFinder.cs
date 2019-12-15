namespace Pipeline.RepositoryManagement.Processing.Configuration.Processes
{
    public interface IProcessFinder
    {
        System.Diagnostics.Process GetShell(string workingDirectory);
        System.Diagnostics.Process GetProcess(string processPath, string workingDirectory, params string[] arguments);
    }
}