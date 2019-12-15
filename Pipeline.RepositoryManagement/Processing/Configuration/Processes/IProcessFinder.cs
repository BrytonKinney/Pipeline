namespace Pipeline.RepositoryManagement.Processing.Configuration.Processes
{
    public interface IProcessFinder
    {
        System.Diagnostics.Process GetShell();
        System.Diagnostics.Process GetProcess(string processPath);
    }
}