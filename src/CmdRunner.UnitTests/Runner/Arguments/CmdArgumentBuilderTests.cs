using CmdRunner.Runner.Arguments;
using Xunit;

namespace CmdRunner.UnitTests.Runner.Arguments
{
    public class CmdArgumentBuilderTests
    {
        private IArgumentBuilder argumentBuilder;
        
        public CmdArgumentBuilderTests()
        {
            argumentBuilder = new CmdArgumentBuilder();
        }

        [Fact]
        public void ShouldSetFlagWithForwardSlash()
        {
            var argument = new Argument("f", null);

            var builtArgument = argumentBuilder.Build(argument);

            Assert.Equal("/f", builtArgument);
        }
    }
}