using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Whiplash.Core.CrossCutting;
using Whiplash.Core.Services.Email;

namespace Whiplash.Core.Services.Email
{
    public class GmailSMTPService : IEmailService
    {
        private string _userId;
        private string _pwd;

        public GmailSMTPService()
        {
            _userId = ConfigurationManager.AppSettings["gmail.id"];
            _pwd = ConfigurationManager.AppSettings["gmail.pwd"];
        }

        public void SendEmail(string to, string subject, string content)
        {
            

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(this._userId);
            mail.Subject = subject;


            mail.Body = content;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            (this._userId, this._pwd);// Enter seders User name and password
            smtp.EnableSsl = true;
            object userState = mail;
            smtp.SendCompleted += Smtp_SendCompleted;
            try
            {
                // smtp.SendAsync(mail, userState);
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                AppFileLogger.getInstance()
                    .Log("email sending failed ,"+
                    " check internet connection :" + ex.Message, MessageType.ERROR);
                throw;
            }
            AppFileLogger.getInstance().Log("email Queued to SMTPServier for:"+to , MessageType.LOG);

        }


        private void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var userState = (MailMessage)e.UserState;
            if (e.Error!=null)
            {
                AppFileLogger.getInstance().Log("email sending failed for :"+userState.To,MessageType.ERROR);
                AppFileLogger.getInstance().Log("email sending failed reason :" + e.Error.Message, MessageType.ERROR);
            }
            else
            {
                AppFileLogger.getInstance().Log("email sending success for :" + userState.To, MessageType.LOG);
            }
        }
    }
}
