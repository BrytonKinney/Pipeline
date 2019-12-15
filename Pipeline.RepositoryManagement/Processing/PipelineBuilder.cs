using System.Threading.Tasks;
using RME = Pipeline.RepositoryManagement.Entities;
using RMPC = Pipeline.RepositoryManagement.Processing.Configuration;
namespace Pipeline.RepositoryManagement.Processing
{
    public class PipelineBuilder : IPipelineBuilder
    {
        private RME.Project _project;
        private RMPC.RepositoryManagementConfiguration _cfg;
        private RMPC.ExecutionEngines.ProcessExecutionEngine _procExecEngine;

        public PipelineBuilder(RMPC.RepositoryManagementConfiguration cfg)
        {
            _cfg = cfg;
        }

        public PipelineBuilder(RME.Project project, RMPC.RepositoryManagementConfiguration cfg) : this(cfg)
        {
            _project = project;
        }

        public PipelineBuilder SetProject(RME.Project project)
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
            }
            return this;
        }
    }
}