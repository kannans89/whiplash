using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiplash.Core.CrossCutting;

namespace Whiplash.Tests
{
    [TestClass]
    public class AppFileLoggerTest
    {
        [TestMethod]
        public void ShouldCreate_and_writetoFile()
        {
            //Arrange
            AppFileLogger logger = AppFileLogger.getInstance();

            //Act
            logger.Log("Hello",MessageType.ERROR);
            logger.Log("Thank you",MessageType.WARNING);

            //Assert
        }
    }
}
