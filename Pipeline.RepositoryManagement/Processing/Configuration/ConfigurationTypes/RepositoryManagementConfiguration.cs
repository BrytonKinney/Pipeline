namespace Pipeline.RepositoryManagement.Processing.Configuration
{
    public class RepositoryManagementConfiguration : IPipelineConfiguration
    {
        public string FileName { get; set; }
        public string DefaultShellPath { get; set; }
        public string Workspace { get; set; }
    }
}