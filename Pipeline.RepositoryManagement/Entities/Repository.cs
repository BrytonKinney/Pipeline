namespace Pipeline.RepositoryManagement.Entities
{
    public class Repository : BaseEntity
    {
        public Repository(string name, string url, Constants.RepositoryKind kind) : base(name)
        {
            Url = url;
            Kind = kind;
        }
        public string Url { get; private set; }
        public Constants.RepositoryKind Kind { get; private set; }
    }
}