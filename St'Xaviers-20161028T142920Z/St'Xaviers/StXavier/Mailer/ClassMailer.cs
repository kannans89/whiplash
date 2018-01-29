using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mail;

namespace MailerLib
{
    public class ClassMailer
    {
        public static bool SendExpiryMail(string EmailID, string DateOfRegistration,string DateOfExpiration, string Name,string MobileNumber,string filePath, string Mno)
        {
            bool retVal = true;
            try
            {
                string mailFrom = ConfigurationSettings.AppSettings["AdminEmail"].ToString();
                string password = ConfigurationSettings.AppSettings["password"].ToString();
                string basePath = ConfigurationSettings.AppSettings["basePath"].ToString();
                string emailBody = ClsCommon.ReadFile(basePath+filePath);
                emailBody = emailBody.Replace("{Name}", Name);
                emailBody = emailBody.Replace("{DateReg}", DateOfRegistration);
                emailBody = emailBody.Replace("{DateExp}", DateOfExpiration);
                emailBody = emailBody.Replace("{Mno}", Mno);
                string subject = ConfigurationSettings.AppSettings["subject"].ToString();
                SendMail(mailFrom, EmailID, subject, emailBody,password);
            }
            catch (Exception ex)
            {
                retVal = false; 
            }
            return retVal;
        }

        private static void SendMail(string mailFrom, string email, string subject, string emailBody,string password)
        {
            //var client = new SmtpClient("217.194.210.201", 587)
            //{
            //    Credentials = new NetworkCredential(mailFrom, password),
            //    EnableSsl = true,
            //    UseDefaultCredentials = false
            //};
            //client.EnableSsl = true;         

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailFrom, password)
            };


            using (var message = new System.Net.Mail.MailMessage(mailFrom,email)
            {
                Subject = subject,
                Body = emailBody,
                IsBodyHtml = true
            })
            {
                client.Send(message);
            }
        }
    }
}