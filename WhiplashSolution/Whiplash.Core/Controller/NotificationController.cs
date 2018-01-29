using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiplash.Core.Data;
using Whiplash.Core.Generated;
using Whiplash.Core.Services.Email;
using Whiplash.Core.Templates;

namespace Whiplash.Core.UI
{
    public class NotificationController
    {
        private Reminder _reminder;
        private GmailSMTPService _emailService;
        private CSVReader _reader;
        private TemplateFormatter _formatter;
        private EmailHistoryRepository _repo;
        public NotificationController()
        {

            _reminder = new Reminder();
            _emailService = new GmailSMTPService();
            _reader = new CSVReader();
            _formatter = new TemplateFormatter();
            _repo = new EmailHistoryRepository();
        }

        public void SendNotification()
        {

            IEnumerable<ContactDTO> contacts = _reader.Read();

            foreach (var contact in contacts)
            {
             

                _reminder.RegistrationDate = contact.ConvertRegistrationToDate();
                if (_reminder.HasExpiryDateApproaching())
                {
                    if (_repo.IsMailSentToday(contact.Id))
                        continue;

                    //_emailService.SendEmail(contact.Email,
                    //"Your IMG registration is expiring " +
                    //_formatter.GetEmailSubject(_reminder), _formatter.GenerateHtml(contact, _reminder));

                    _emailService.SendEmail(contact.Email,
                    " Membership Reminder from the IMG ", _formatter.GenerateHtml(contact, _reminder));




                    var history = new EmailHistory()
                    {
                        ContactID = contact.Id,
                        LastEmailSent = DateTime.Today,
                        Name = contact.Name
                    }; 
                    history.TotalReminders += 1;
                    _repo.Add(history);


                }

            }

        }


    }
}
