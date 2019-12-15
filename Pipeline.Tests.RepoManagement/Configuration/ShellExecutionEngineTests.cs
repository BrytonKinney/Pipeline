using NUnit.Framework;
using Pipeline.RepositoryManagement.Processing.Configuration;
using Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines;
using Pipeline.RepositoryManagement.Processing.Configuration.Processes;
using System.Threading.Tasks;

namespace Pipeline.Tests.RepositoryManagement.Configuration
{
    [TestFixture]
    public class ShellExecutionEngineTests
    {
        [Test]
        public async Task ShellExecutionEngine_RunEchoHelloWorld_ReturnsHelloWorld()
        {
            var procFinder = new Moq.Mock<IProcessFinder>();
            var shell = new System.Diagnostics.Process();
            string shellPath = string.Empty;
            if (System.Environment.OSVersion.Platform == System.PlatformID.Win32NT)
                shellPath = "C:\\Windows\\System32\\cmd.exe";
            else if(System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                shellPath = "/usr/bin/bash";
            shell.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = shellPath, UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true };
            procFinder.Setup(pf => pf.GetShell()).Returns(shell);
            var shellExec = new ProcessExecutionEngine(procFinder.Object);
            var output = await shellExec.ExecuteCommandAsync(new Command() { ExecutionInstructions = "echo Hello World!", Name = "Hello World", Order = 1, Type = "shell" });
            Assert.IsFalse(string.IsNullOrWhiteSpace(output));
            Assert.IsTrue(output.Contains("Hello World!"));
        }
    }
}
