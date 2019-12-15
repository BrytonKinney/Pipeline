using NUnit.Framework;
using Pipeline.RepositoryManagement.Processing.Configuration;
using Pipeline.RepositoryManagement.Processing.Configuration.Processes;
using System;

namespace Pipeline.Tests.RepositoryManagement.Configuration
{
    [TestFixture]
    public class ProcessFinderTests
    {
        [Test]
        public void ProcessFinderTests_NoDefaultShellPath_ReturnsDefaultPlatformSpecificShell()
        {
            var procFinder = new ProcessFinder(new RepositoryManagementConfiguration());
            using (var shell = procFinder.GetShell())
            {
                shell.Start();
                if (System.Environment.OSVersion.Platform == PlatformID.Win32NT)
                    Assert.AreEqual("cmd", shell.ProcessName);
                else
                    Assert.AreEqual("bash", shell.ProcessName);
            }
        }
    }
}
