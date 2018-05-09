using System;
using CmdRunner;
namespace CmdRunner.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic cmd = new Cmd();
            var gitOutput = cmd.git.config(get: "user.name");
            Console.WriteLine(gitOutput);
        }
    }
}
