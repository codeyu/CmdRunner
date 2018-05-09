using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CmdRunner.Commands;
using CmdRunner.Runner.Arguments;

namespace CmdRunner.Runner.Shells
{
    internal class ProcessRunner : IRunner
    {
        private readonly Lazy<IArgumentBuilder> _argumentBuilder = new Lazy<IArgumentBuilder>(() => new ArgumentBuilder());

        protected virtual IArgumentBuilder ArgumentBuilder
        {
            get { return _argumentBuilder.Value; }
        }

        public string BuildArgument(Argument argument)
        {
            return ArgumentBuilder.Build(argument);
        }

        public IDictionary<string, string> EnvironmentVariables { get; set; }

        public virtual ICommando GetCommand()
        {
            return new Commando(this);
        }

        public virtual string Run(IRunOptions runOptions)
        {
            var process = new Process
                        {
                            StartInfo =
                                {
                                    FileName = runOptions.Command,
                                    WindowStyle = ProcessWindowStyle.Hidden,
                                    CreateNoWindow = true,
                                    Arguments = runOptions.Arguments,
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true
                                },
                                EnableRaisingEvents = true
                        };
            PopulateEnvironment(process);
            StringBuilder output = new StringBuilder();
            process.Start();
            output.Append(process.StandardOutput.ReadToEnd());
            output.Append(process.StandardError.ReadToEnd());
            process.WaitForExit();

            return output.ToString();
        }

        private void PopulateEnvironment(Process process)
        {
            foreach (var variable in EnvironmentVariables)
            {
                process.StartInfo.EnvironmentVariables[variable.Key] = variable.Value;
            }
        }
    }
}
