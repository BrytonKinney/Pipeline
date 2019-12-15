using NUnit.Framework;
using Pipeline.RepositoryManagement.Processing.Configuration;
using Pipeline.RepositoryManagement.Processing.Configuration.ExecutionEngines;
using Pipeline.RepositoryManagement.Processing.Configuration.Processes;
using Pipeline.RepositoryManagement.Processing.Events.EventArgs;
using System.Diagnostics;
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
            else if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                shellPath = "/bin/bash";
            System.Console.WriteLine(string.Format("shellPath: {0}", shellPath));
            System.Console.WriteLine(string.Format("File Name: {0}", System.IO.Path.GetFileName(shellPath)));
            System.Console.WriteLine(string.Format("Directory Name: {0}", System.IO.Path.GetDirectoryName(shellPath)));
            shell.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = shellPath, UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true };
            procFinder.Setup(pf => pf.GetShell(Moq.It.IsAny<string>())).Returns(shell);
            var shellExec = new ProcessExecutionEngine(procFinder.Object);
            string output = string.Empty;
            shellExec.OnProcessOutputReceived += (object sender, ProcessOutputEventArgs args) =>
            {
                System.Console.WriteLine(string.Format("Output received: {0}", args.Output));
                output = string.Concat(output, args.Output);
            };
            await shellExec.ExecuteCommandAsync(new Command()
            {
                ExecutionInstructions = "echo Hello World!",
                Name = "Hello World",
                Order = 1,
                Type = "shell",
                Arguments = null
            });
            Assert.IsFalse(string.IsNullOrWhiteSpace(output));
            Assert.IsTrue(output.Contains("Hello World!"));
        }

        [Test]
        public async Task ShellExecutionEngine_RunTests_ReturnsHelloWorld()
        {
            var shellExec = new ProcessExecutionEngine(new ProcessFinder(new RepositoryManagementConfiguration()));
            string output = string.Empty;
            shellExec.OnProcessOutputReceived += (object sender, ProcessOutputEventArgs args) =>
            {
                System.Console.WriteLine(string.Format("Output received: {0}", args.Output));
                output = string.Concat(output, args.Output);
            };
            int exit = -1;
            shellExec.OnExit += (object sender, ProcessExitedEventArgs args) =>
            {
                exit = args.ExitCode;
                System.Console.WriteLine("Exited with {0}", args.ExitCode);
                System.Console.WriteLine("Exited at {0}", args.ExitTime);
            };
            string asmDir = System.IO.Path.Combine(PipeTestHelper.GetSolutionPath(), "TestProject");
            System.Console.WriteLine(string.Format("Executing assembly directory: {0}", asmDir));
            await shellExec.ExecuteCommandAsync(new Command()
            {
                ExecutionInstructions = "dotnet",
                Name = "Test Run",
                Order = 1,
                Type = "process",
                Arguments = new string[] { "build" },
                WorkingDirectory = asmDir
            });
            Assert.IsFalse(string.IsNullOrWhiteSpace(output));
            Assert.AreEqual(0, exit);
        }
    }
}
