using CmdRunner.Runner;

namespace CmdRunner.Commands
{
    internal class CmdCommando : Commando
    {
        public CmdCommando(IRunner runner) : base(runner)
        {
            commands.Add("cmd");
            commands.Add("/c");
        }
    }
}