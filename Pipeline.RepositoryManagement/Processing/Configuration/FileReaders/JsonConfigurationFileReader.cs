using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Pipeline.RepositoryManagement.Processing.Configuration.FileReaders
{
    public class JsonConfigurationFileReader<TConfiguration> : IConfigurationFileReader<TConfiguration> where TConfiguration : IPipelineConfiguration
    {
        public async Task<TConfiguration> ReadConfigurationAsync(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var cfg = await JsonSerializer.DeserializeAsync<TConfiguration>(fs, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                cfg.FileName = Path.GetFileName(filePath);
                return cfg;
            }
        }
    }
}
