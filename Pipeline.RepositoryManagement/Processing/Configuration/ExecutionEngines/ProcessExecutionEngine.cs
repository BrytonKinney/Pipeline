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

        public override Process GetProcess(CommandType commandType, string processPath)
        {
            if (commandType == CommandType.Process)
                return _processFinder.GetProcess(processPath);
            else if (commandType == CommandType.Shell)
                return _processFinder.GetShell();
            throw new System.ArgumentException(nameof(commandType));
        }
    }
}
