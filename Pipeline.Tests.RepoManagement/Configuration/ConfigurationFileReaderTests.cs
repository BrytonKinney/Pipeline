using NUnit.Framework;
using System.Threading.Tasks;
using Pipeline.RepositoryManagement.Processing.Configuration;
namespace Pipeline.Tests.RepoManagement
{
    [TestFixture]
    public class ConfigurationFileReaderTests
    {
        [Test]
        public async Task YamlConfigurationFileReader_ReadInValidBuildYamlCfg_Pass()
        {
            var yaml = new YamlConfigurationFileReader<BuildConfiguration>();
            var result = await yaml.ReadConfigurationAsync(PipeTestHelper.GetFilePath("ExampleFiles/buildCfg1.yaml"));
            Assert.IsNotNull(result, "YAML BuildConfiguration was null.");
            Assert.IsNotNull(result.Stages, "YAML Stages was null.");
        }

        [Test]
        public async Task YamlConfigurationFileReader_ReadInValidRepoManYamlCfg_Pass()
        {
            var yaml = new YamlConfigurationFileReader<RepositoryManagementConfiguration>();
            var result = await yaml.ReadConfigurationAsync(PipeTestHelper.GetFilePath("ExampleFiles/pipelineCfg1_Linux.yaml"));
            Assert.IsNotNull(result, "YAML RepositoryManagementConfiguration was null.");
            Assert.IsNotNull(result.Workspace, "YAML Workspace was null.");
            Assert.IsNotNull(result.DefaultShellPath);
        }
    }
}
