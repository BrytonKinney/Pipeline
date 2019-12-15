using NUnit.Framework;
using System.Threading.Tasks;
using Pipeline.RepositoryManagement.Processing.Configuration;
using Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines;

namespace Pipeline.Tests.RepoManagement
{
    [TestFixture]
    public class ShellExecutionEngineTests
    {
        [Test]
        public async Task ShellExecutionEngine_RunEchoHelloWorld_ReturnsHelloWorld()
        {
            var moqProcFinder = new Moq.Mock<IProcessFinder>();
            var shell = new ShellExecutionEngine()
        }
    }
}
