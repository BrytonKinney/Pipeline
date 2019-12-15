namespace Pipeline.RepositoryManagement.Entities
{
    public class Project : BaseEntity
    {
        public Project(string name, string version, Repository projectRepository, Workspace workspace, PipelineConfiguration configuration) : base(name)
        {
            Version = version;
            ProjectRepository = projectRepository;
            ProjectWorkspace = workspace;
            BuildConfiguration = configuration;
        }
        public Repository ProjectRepository { get; private set; }
        public Workspace ProjectWorkspace { get; private set; }
        public PipelineConfiguration BuildConfiguration { get; private set; }
        public string Version { get; private set; }
    }
}