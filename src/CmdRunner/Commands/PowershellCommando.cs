using System;
using System.Dynamic;
using System.Runtime.Serialization.Formatters.Binary;

namespace CmdRunner.Commands
{
    public class PowershellCommando : DynamicObject, ICommando
    {
        public string Command { get; private set; }
        public string Arguments { get; private set; }
        public void AddCommand(string command)
        {
            throw new System.NotImplementedException();
        }
    }

}