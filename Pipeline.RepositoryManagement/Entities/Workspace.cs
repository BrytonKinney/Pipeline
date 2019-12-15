namespace Pipeline.RepositoryManagement.Entities
{
    public class Workspace : BaseEntity
    {
        public Workspace(string name, string path) : base(name)
        {
            Path = path;
        }
        public string Path { get; private set; }
    }
}