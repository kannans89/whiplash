using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiplash.Core.UI;

namespace Whiplash.Tests
{
    [TestClass]
    public class NotificationControllerTest
    {
        [TestMethod]
        public void ShouldSendNotifcationWithoutFailure()
        {
            NotificationController contoller =new NotificationController();
            contoller.SendNotification();
        }
    }
}
