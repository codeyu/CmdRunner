using CmdRunner.Commands;

namespace CmdRunner.Runner
{
    internal class RunOptions : IRunOptions
    {
        public RunOptions(ICommando commando)
        {
            Command = commando.Command;
            Arguments = commando.Arguments;
        }

        public string Command { get; set; }
        public string Arguments { get; set; }
    }
}