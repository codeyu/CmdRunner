﻿namespace CmdRunner.Runner
{
    public interface IRunOptions
    {
        string Command { get; set; }
        string Arguments { get; set; }
    }
}