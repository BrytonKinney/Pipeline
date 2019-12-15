using RME = Pipeline.RepositoryManagement.Entities;
namespace Pipeline.RepositoryManagement.Processing
{
    public class PipelineBuilder : IPipelineBuilder
    {
        private RME.Project _project;
        public PipelineBuilder(RME.Project project)
        {
            _project = project;
        }

        public void BuildProject()
        {

        }
    }
}