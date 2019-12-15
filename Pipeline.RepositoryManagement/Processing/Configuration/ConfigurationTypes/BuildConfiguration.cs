using System.Collections.Generic;

namespace Pipeline.RepositoryManagement.Processing.Configuration
{
    public class BuildConfiguration : IPipelineConfiguration
    {
        public string FileName { get; set; }
        public IEnumerable<Stage> Stages { get; set; }
    }
}