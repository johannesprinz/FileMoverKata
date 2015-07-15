using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FileMoverKata.Console;
using FluentAssertions;
using Moq;

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

        [Test]
        public void Given_NullSource_ItTrowsArgumentNullException()
        {
            Action action = () => new FileMover().MoveFiles(null, It.IsAny<string>(), It.IsAny<string>());
            action.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: path");
        }
    }
}


