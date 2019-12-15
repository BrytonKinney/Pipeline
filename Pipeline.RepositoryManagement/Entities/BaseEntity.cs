namespace Pipeline.RepositoryManagement.Entities
{
    public class BaseEntity
    {
        public BaseEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public BaseEntity(string name)
        {
            Name = name;
        }
        public int Id { get; protected set; }
        public string Name { get; protected set; }
    }
}