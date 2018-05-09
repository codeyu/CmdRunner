﻿using System.Collections.Generic;
using Moq;
using CmdRunner.Commands;
using CmdRunner.Runner;
using Xunit;

namespace CmdRunner.UnitTests
{
    public class CmdTests
    {
        private dynamic cmd;
        private Mock<IRunner> mockRunner;

        public CmdTests()
        {
            mockRunner = new Mock<IRunner>();
            mockRunner.Setup(runner => runner.GetCommand()).Returns(new Commando(mockRunner.Object));
            cmd = new Cmd(mockRunner.Object);
        }

        [Fact]
        public void ShouldBeAbleToBuildACommandAsProperty()
        {
            var commando = cmd.git;
            
            Assert.NotNull(commando);
        }

        [Fact]
        public void ShouldCreateCommandWithRunner()
        {
            cmd.git();

            mockRunner.Verify(runner => runner.Run(It.IsAny<IRunOptions>()), Times.Once());
        }

        [Fact]
        public void ShouldBeAbleToBuildMultipleCommandsOnCmd()
        {
            mockRunner.Setup(runner => runner.GetCommand()).Returns(new Commando(mockRunner.Object));
            var git = cmd.git;
            mockRunner.Setup(runner => runner.GetCommand()).Returns(new Commando(mockRunner.Object));
            var svn = cmd.svn;

            Assert.NotEqual(svn, git);
        }

        [Fact]
        public void ShouldBeAbleToRunMultipleCommandsOnCmd()
        {
            mockRunner.Setup(runner => runner.GetCommand()).Returns(new Commando(mockRunner.Object));
            cmd.git();
            mockRunner.Setup(runner => runner.GetCommand()).Returns(new Commando(mockRunner.Object));
            cmd.svn();

            mockRunner.Verify(runner => runner.Run(It.Is<IRunOptions>(options => options.Command == "git")), Times.Once());
            mockRunner.Verify(runner => runner.Run(It.Is<IRunOptions>(options => options.Command == "svn")), Times.Once());
        }

        [Fact]
        public void ShouldBeAbleToSetEnvironmentVariablesOnCmd()
        {
            var environmentDictionary = new Dictionary<string, string> { { "PATH", @"C:\" } };
            cmd._Env(environmentDictionary);

            mockRunner.VerifySet(runner => runner.EnvironmentVariables = environmentDictionary);
        }
    }
}