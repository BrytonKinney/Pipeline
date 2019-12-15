using Pipeline.RepositoryManagement.Processing.Configuration;

namespace Pipeline.RepositoryManagement.Entities
{
    public class Project : BaseEntity
    {
        public Project(string name, string version, Repository projectRepository, Workspace workspace, BuildConfiguration config) : base(name)
        {
            Version = version;
            ProjectRepository = projectRepository;
            ProjectWorkspace = workspace;
            Configuration = config;
        }
        public Repository ProjectRepository { get; private set; }
        public Workspace ProjectWorkspace { get; private set; }
        public BuildConfiguration Configuration { get; private set; }
        public string Version { get; private set; }
    }
}