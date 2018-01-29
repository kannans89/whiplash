using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiplash.Core;

namespace Whiplash.Tests
{
    [TestClass]
    public class RegistrationExpiryReminderTest
    {
        [TestMethod]
        public void Reminder1_ShouldBeAfter_11Months_Of_Registration()
        {

           //Arrange
           DateTime dateOfRegsitration=new DateTime(2015,11,30);
           Reminder reminder= new Reminder(dateOfRegsitration);
           DateTime expected_dateAfter_11Months = new DateTime(2016,10,30);
            //keep todays date for this parameter


          // Act
            DateTime actualDateFrom_API = reminder.FirstReminderDate;

            //Assert
            Assert.AreEqual(expected_dateAfter_11Months,actualDateFrom_API);
            Assert.IsTrue(reminder.HasExpiryDateApproaching());
        }


        [TestMethod]
        public void Reminder2_ShouldBefore_aWeek_ofExpiry()
        {

            //Arrange
            DateTime dateOfRegsitration = new DateTime(2015, 11, 06);
            Reminder reminder = new Reminder(dateOfRegsitration);
            DateTime expected_date_beforeAWeek = new DateTime(2016, 10, 30);
            //keep todays date for this parameter


            // Act
            DateTime actualDateFrom_API = reminder.SecondReminderDate;

            //Assert
            Assert.AreEqual(expected_date_beforeAWeek, actualDateFrom_API);
            Assert.IsTrue(reminder.HasExpiryDateApproaching());
        }

        [TestMethod]
        public void Reminder3_Should_OnDay_ofExpiry()
        {

            //Arrange
            DateTime dateOfRegsitration = new DateTime(2015, 10, 30);
            Reminder reminder = new Reminder(dateOfRegsitration);
            DateTime expected_day_ofExpiry = new DateTime(2016, 10, 30);
            //keep todays date for this parameter


            // Act
            DateTime actualDateFrom_API = reminder.ThirdReminderDate;

            //Assert
            Assert.AreEqual(expected_day_ofExpiry, actualDateFrom_API);
            Assert.IsTrue(reminder.HasExpiryDateApproaching());
        }

        [TestMethod]
        public void ShouldSendEmailNotficationToday_IfExpirtyDateReached()
        {

            //Arrange
            DateTime dateOfRegsitration = new DateTime(2015, 10, 30);
            Reminder reminder = new Reminder(dateOfRegsitration);
            DateTime expected_day_ofExpiry = new DateTime(2016, 10, 30);
            //keep todays date for this parameter


            // Act
            DateTime actualDateFrom_API = reminder.ThirdReminderDate;

            //Assert
            Assert.AreEqual(expected_day_ofExpiry, actualDateFrom_API);
            Assert.IsTrue(reminder.HasExpiryDateApproaching());

        }

        [TestMethod]
        public void VijayTestCase_1()
        {
            //Arrange
            DateTime dateOfRegsitration = new DateTime(2015, 11, 30);
            Reminder reminder = new Reminder(dateOfRegsitration);
            DateTime expected_day_ofExpiry = new DateTime(2016, 11, 29);
            //keep todays date for this parameter


            // Act
           // DateTime actualDateFrom_API = reminder.ThirdReminderDate;

            //Assert
            //Assert.AreEqual(expected_day_ofExpiry, actualDateFrom_API);
            Assert.IsTrue(reminder.HasExpiryDateApproaching());


        }


    }
}
