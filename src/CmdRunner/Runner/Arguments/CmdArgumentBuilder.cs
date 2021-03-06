﻿namespace CmdRunner.Runner.Arguments
{
    internal class CmdArgumentBuilder : ArgumentBuilder
    {
        protected override string BuildFlag(Argument argument)
        {
            return argument.Flag == null ? null : string.Format("/{0}", argument.Flag);
        }
    }
}
