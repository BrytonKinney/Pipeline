namespace Pipeline.RepositoryManagement.Processing.Configuration
{
    public class Command
    {
        public string Type { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string ExecutionInstructions { get; set; }
    }
}