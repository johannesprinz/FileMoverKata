using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FileMoverKata.Console;
using FluentAssertions;

namespace FileMoverKata.Tests
{
    [TestFixture]
    public class FileMoverTests
    {
        [Test]
        public void Given_NoDependencies_ItStillConstructs()
        {
            Action action = () => new FileMover();
            action.ShouldNotThrow();
        }
    }
}
