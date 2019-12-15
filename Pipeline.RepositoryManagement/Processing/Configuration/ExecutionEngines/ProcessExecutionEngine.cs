using Pipeline.RepositoryManagement.Constants;
using Pipeline.RepositoryManagement.Processing.Configuration.Processes;
using System;
using System.Diagnostics;

namespace Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines
{
    public class ProcessExecutionEngine : BaseProcessExecutionEngine
    {
        private readonly IProcessFinder _processFinder;

        public ProcessExecutionEngine(IProcessFinder processFinder)
        {
            _processFinder = processFinder;
        }

        public override Process GetProcess(CommandType commandType, string processPath, string workingDirectoryPath, params string[] arguments)
        {
            if (commandType == CommandType.Process)
                return _processFinder.GetProcess(processPath, workingDirectoryPath, arguments);
            else if (commandType == CommandType.Shell)
                return _processFinder.GetShell(workingDirectoryPath);
            throw new System.ArgumentException(nameof(commandType));
        }
    }
}
