using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiplash.Core.Data;

namespace Whiplash.Core.Templates
{
    public class TemplateFormatter
    {


        public string GenerateHtml(ContactDTO contact, Reminder reminder)
        {
            if (reminder.HasExpiryDateApproaching())
            {
                string html;
                using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\MailTemplate.html"))
                {
                    html = sr.ReadToEnd();
                }

                html = html.Replace("{name}", contact.Name);
                html = html.Replace("{registrationDate}", contact.RegistrationDate);
                html = html.Replace("{Id}", contact.Id);
                html = html.Replace("{expiryDayType}", GetFormattedOccuranceType(reminder));
                html = html.Replace("{expiryDate}", reminder.ThirdReminderDate.ToString("dd-MM-yyyy"));

                return html;
            }
            return string.Empty;
        }

        private string GetFormattedOccuranceType(Reminder reminder)
        {
            OccuranceType occurance = reminder.FindOccuranceType();
            if (occurance == OccuranceType.BEFORE_MONTH)
                return " will get";
            else if (occurance == OccuranceType.BEFORE_WEEK)
                return " will get";
            else if (occurance == OccuranceType.LAST_DAY)
                return "has";
            else return string.Empty;

        }

        public string GetEmailSubject(Reminder reminder)
        {
            OccuranceType occurance = reminder.FindOccuranceType();
            if (occurance == OccuranceType.BEFORE_MONTH)
                return " in a month";
            else if (occurance == OccuranceType.BEFORE_WEEK)
                return " in a week";
            else if (occurance == OccuranceType.LAST_DAY)
                return "today";
            else return string.Empty;

        }


    }
}
