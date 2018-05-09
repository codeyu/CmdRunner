using CmdRunner.Runner.Shells;
using Xunit;

namespace CmdRunner.UnitTests.Runner.Shells
{
    public class ShellTests
    {
        [Fact]
        public void ShouldReturnAProcessRunnerAsDEfaul()
        {
            Assert.IsAssignableFrom<ProcessRunner>(Shell.Default);
        }

        [Fact]
        public void ShouldReturnACmdShellRunner()
        {
            Assert.IsAssignableFrom<CmdShell>(Shell.Cmd);
        }

        [Fact]
        public void ShouldReturnAPowerShellRunner()
        {
            Assert.IsAssignableFrom<Pwsh>(Shell.Powershell);
        }
    }
}
