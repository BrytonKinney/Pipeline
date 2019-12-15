using System.Threading.Tasks;

namespace Pipeline.RepositoryManagement.Processing.Configuration
{
    public interface IConfigurationFileReader<TConfiguration>
    {
        Task<TConfiguration> ReadConfigurationAsync(string filePath);
    }
}