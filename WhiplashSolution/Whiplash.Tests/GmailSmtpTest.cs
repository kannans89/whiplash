using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiplash.Core.Services.Email;

namespace Whiplash.Tests
{
    /// <summary>
    /// Summary description for GmailSmtpTest
    /// </summary>
    [TestClass]
    public class GmailSmtpTest
    {

        [TestMethod]
        public void ShouldSendEmail()
        {
            GmailSMTPService service =new GmailSMTPService();
            service.SendEmail("gwa.kannan@gmail.com","test","<h1>Test</h1>");

        }
    }
}
