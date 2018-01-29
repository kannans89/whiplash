using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiplash.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace Whiplash.Tests
{
    [TestClass]
    public class CSVReaderTest
    {
        [TestMethod]
        public void ShouldReadFile()
        {
            CSVReader dr =new CSVReader();
            List<ContactDTO> contacts=  dr.Read().ToList();

            Assert.IsTrue(contacts.Count()>2);
        }
    }
}
