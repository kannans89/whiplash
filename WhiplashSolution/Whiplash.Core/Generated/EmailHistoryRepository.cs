using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiplash.Core.CrossCutting;

namespace Whiplash.Core.Generated
{
    public class EmailHistoryRepository
    {
        private static string EMAIL_HISTORY_FILE = "\\EmailHistory.txt";

        public void Add(EmailHistory contact)
        {
            if (!String.IsNullOrEmpty(contact.ContactID))
            {
           using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + EMAIL_HISTORY_FILE,true))
                {
                    sw.WriteLine(contact.ContactID + ","
                        +contact.Name+","
                        +contact.LastEmailSent.ToShortDateString()+ ","
                        + contact.TotalReminders);
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                AppFileLogger.getInstance().Log("No field values for EmailedContacts",MessageType.WARNING);
            }

        }

        public List<EmailHistory> Get()
        {
            List<EmailHistory> contacts = new List<EmailHistory>();

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + EMAIL_HISTORY_FILE))
                return null;

            using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + EMAIL_HISTORY_FILE))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split(',');

                    contacts.Add(new EmailHistory()
                    {
                        ContactID = data[0],
                        Name = data[1],
                        LastEmailSent = DateTime.Parse(data[2]),
                        TotalReminders =int.Parse(data[3])
                    });

                    line = sr.ReadLine();

                }

            }
            return contacts;
        }


        public bool IsMailSentToday(string contactId)
        {
            if (!String.IsNullOrEmpty(contactId))
            {
                if (Get() == null)
                    return false;

                List<EmailHistory> contacts = Get();
                var mailedUsersToday = contacts
                    .Where((x) => x.ContactID.Equals(contactId) &&
                                  x.LastEmailSent.Equals(DateTime.Today));


                var mailedHistoryList = mailedUsersToday.ToList();

                if (mailedHistoryList.Count > 0)
                    return true;
            }

            return false;

        }

    }
}
