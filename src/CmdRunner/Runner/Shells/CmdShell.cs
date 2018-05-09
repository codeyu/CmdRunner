using System;
using CmdRunner.Commands;
using CmdRunner.Runner.Arguments;

namespace CmdRunner.Runner.Shells
{
    internal class CmdShell : ProcessRunner
    {
        private readonly Lazy<IArgumentBuilder> argumentBuilder = new Lazy<IArgumentBuilder>(() => new CmdArgumentBuilder());

        protected override IArgumentBuilder ArgumentBuilder
        {
            get { return argumentBuilder.Value; }
        }

        public override ICommando GetCommand()
        {
            return new CmdCommando(this);
        }
    }
}