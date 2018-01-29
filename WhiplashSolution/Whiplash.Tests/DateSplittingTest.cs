using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Whiplash.Tests
{
    [TestClass]
    public class DateSplittingTest
    {
        [TestMethod]
        public void ShouldSplitDates()
        {
            String stringDate = "16-09-2015";
           string[] splittedDate= stringDate.Split('-');
           int date = int.Parse(splittedDate[0]);
           int month = int.Parse(splittedDate[1]);
           int year = int.Parse(splittedDate[2]);

            Assert.IsTrue(date==16);
            Assert.IsTrue(month == 9);
            Assert.IsTrue(year == 2015);





        }
    }
}
