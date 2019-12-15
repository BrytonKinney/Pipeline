using System.Collections.Generic;
namespace Pipeline.RepositoryManagement.Processing.Configuration
{
    public class Stage
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public IEnumerable<Command> Commands { get; set; }
    }
}