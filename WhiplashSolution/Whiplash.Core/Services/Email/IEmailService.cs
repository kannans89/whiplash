using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Whiplash.Core.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string content);
    }
}
