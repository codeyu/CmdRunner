using System.Collections.Generic;
using CmdRunner.Commands;

namespace CmdRunner.Runner
{
    public interface IRunner
    {
        string Run(IRunOptions runOptions);
        string BuildArgument(Arguments.Argument argument);
        IDictionary<string, string> EnvironmentVariables { get; set; }
        ICommando GetCommand();
    }
}