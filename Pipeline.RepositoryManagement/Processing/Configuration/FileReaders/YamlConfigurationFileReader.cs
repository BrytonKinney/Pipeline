using System.IO;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Pipeline.RepositoryManagement.Processing.Configuration
{
    public class YamlConfigurationFileReader<TConfiguration> : IConfigurationFileReader<TConfiguration>
    {
        private readonly IDeserializer _deserializer;

        public YamlConfigurationFileReader()
        {
            _deserializer = new DeserializerBuilder()
                                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                    .Build();
        }

        public async Task<TConfiguration> ReadConfigurationAsync(string filePath)
        {
            StringBuilder configuration = new StringBuilder(4096 * 2);
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                        configuration.AppendLine(await reader.ReadLineAsync());
                }
            }
            return _deserializer.Deserialize<TConfiguration>(configuration.ToString());
        }
    }
}