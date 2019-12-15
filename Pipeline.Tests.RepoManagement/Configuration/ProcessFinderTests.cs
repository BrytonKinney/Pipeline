using NUnit.Framework;
using Pipeline.RepositoryManagement.Processing.Configuration.Processes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Tests.RepoManagement.Configuration
{
    [TestFixture]
    public class ProcessFinderTests
    {
        [Test]
        public void ProcessFinderTests_NoDefaultShellPath_ReturnsDefaultPlatformSpecificShell()
        {
            var procFinder = new ProcessFinder(new RepositoryManagement.Processing.Configuration.RepositoryManagementConfiguration());
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
