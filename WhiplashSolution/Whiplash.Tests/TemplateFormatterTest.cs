using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiplash.Core.Data;
using Whiplash.Core.Templates;
using Whiplash.Core;

namespace Whiplash.Tests
{
    [TestClass]
    public class TemplateFormatterTest
    {
        [TestMethod]
        public void ShouldReadHtmlFile_and_FormatData_Month()
        {
            ContactDTO dto = new ContactDTO();
            dto.Id = "1235";
            dto.RegistrationDate = "30-11-2015";
            dto.Name = "Kannan";
            dto.Email = "gwa.kannan@gmail.com";

            var registrationDate = dto.ConvertRegistrationToDate()
                .AddMonths(1);
                           


            Reminder reminder = new Reminder();
            reminder.RegistrationDate = dto.ConvertRegistrationToDate();

            TemplateFormatter formatter = new TemplateFormatter();
            var str = formatter.GenerateHtml(dto, reminder);

            Assert.IsTrue(str.Length > 0);
            Assert.IsTrue(str.Contains("Kannan"));
            Assert.IsTrue(str.Contains(dto.Id));
            Assert.IsTrue(str.Contains("month"));

        }

        [TestMethod]
        public void ShouldReadHtmlFile_and_FormatData_Week()
        {
            ContactDTO dto = new ContactDTO();
            dto.Id = "1235";
            dto.RegistrationDate = "06-11-2015";
            dto.Name = "Kannan";
            dto.Email = "gwa.kannan@gmail.com";

            var registrationDate = dto.ConvertRegistrationToDate()
                           .AddMonths(12)
                           .AddDays(-7);


            Reminder reminder = new Reminder();
            reminder.RegistrationDate = dto.ConvertRegistrationToDate();

            TemplateFormatter formatter = new TemplateFormatter();
            var str = formatter.GenerateHtml(dto, reminder);

            Assert.IsTrue(str.Length>0);
            Assert.IsTrue(str.Contains("Kannan"));
            Assert.IsTrue(str.Contains(dto.Id));
            Assert.IsTrue(str.Contains("week"));

        }


        [TestMethod]
        public void ShouldReadHtmlFile_and_FormatData_Today()
        {
            ContactDTO dto = new ContactDTO();
            dto.Id = "1235";
            dto.RegistrationDate = "30-10-2015";
            dto.Name = "Kannan";
            dto.Email = "gwa.kannan@gmail.com";
            

            Reminder reminder =new Reminder();
            reminder.RegistrationDate = dto.ConvertRegistrationToDate();

            TemplateFormatter formatter =new TemplateFormatter();
            var str=formatter.GenerateHtml(dto,reminder);

            Assert.IsNotNull(str);
            Assert.IsTrue(str.Contains("Kannan"));
            Assert.IsTrue(str.Contains(dto.Id));
            Assert.IsTrue(str.Contains("today"));

        }
    }
}
