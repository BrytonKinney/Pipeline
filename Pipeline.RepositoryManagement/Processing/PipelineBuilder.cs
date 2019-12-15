using System;
using System.Threading.Tasks;
using Entities = Pipeline.RepositoryManagement.Entities;
using Configuration = Pipeline.RepositoryManagement.Processing.Configuration;
using ProcessingEvents = Pipeline.RepositoryManagement.Processing.Events;
namespace Pipeline.RepositoryManagement.Processing
{
    public class PipelineBuilder : IPipelineBuilder
    {
        private Entities.Project _project;
        private Configuration.RepositoryManagementConfiguration _cfg;
        private Configuration.ExecutionEngines.ProcessExecutionEngine _procExecEngine;

        public PipelineBuilder(Configuration.RepositoryManagementConfiguration cfg)
        {
            _cfg = cfg;
            _procExecEngine = new Processing.Configuration.ExecutionEngines.ProcessExecutionEngine(new Processing.Configuration.Processes.ProcessFinder(cfg));
            _procExecEngine.OnProcessOutputReceived += ProcessOutputReceived;
        }

        public PipelineBuilder(Entities.Project project, Configuration.RepositoryManagementConfiguration cfg) : this(cfg)
        {
            _project = project;
        }

        public PipelineBuilder SetProject(Entities.Project project)
        {
            _project = project;
            return this;
        }

        public async Task<PipelineBuilder> BuildProject()
        {
            if (_project == null)
                throw new System.NullReferenceException("No project has been set. Please call SetProject(Pipeline.RepositoryManagement.Entities project) before building.");
            foreach (var stage in _project.Configuration.Stages)
            {
                foreach(var cmd in stage.Commands)
                {
                    await _procExecEngine.ExecuteCommandAsync(cmd);
                }
                OnStageCompleted?.Invoke(this, new ProcessingEvents.EventArgs.StageCompletedEventArgs(stage));
            }
            return this;
        }
        private void ProcessOutputReceived(object sender, ProcessingEvents.EventArgs.ProcessOutputEventArgs args)
        {
            OnProcessOutput?.Invoke(sender, args);
        }
        public EventHandler<ProcessingEvents.EventArgs.StageCompletedEventArgs> OnStageCompleted;
        public EventHandler<ProcessingEvents.EventArgs.ProcessOutputEventArgs> OnProcessOutput;
    }
}