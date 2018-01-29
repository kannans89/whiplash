using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiplash.Core.Generated;

namespace Whiplash.Tests
{
    [TestClass]
    public class EmailedContactManagerTest
    {
        [TestMethod]
        public void ShouldAddNew_MapEntires()
        {
            EmailHistoryRepository manager = new EmailHistoryRepository();
            manager.Add(new EmailHistory()
            {
                LastEmailSent = DateTime.Today,
                ContactID = "K2001",
                Name = "Kannapi"

            });
        }

        [TestMethod]
        public void ShouldRead_MapEntires()
        {
            EmailHistoryRepository manager = new EmailHistoryRepository();
            Assert.IsTrue(manager.Get().Count > 0);
        }

        [TestMethod]
        public void MailNotSentForThisEntry()
        {
            EmailHistoryRepository manager = new EmailHistoryRepository();
            var contact = new EmailHistory()
            {
                LastEmailSent = DateTime.Today,
                ContactID = "AB-3215"

            };
            Assert.IsTrue(!manager.IsMailSentToday(contact.ContactID));
        }

    }
}
