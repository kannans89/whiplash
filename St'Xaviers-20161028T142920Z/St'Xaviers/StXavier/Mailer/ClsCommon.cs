using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailerLib
{
    class ClsCommon
    {
        public static string ReadFile(string path)
        {
            string Content = string.Empty;

            Content = File.ReadAllText(path);

            return Content;
        }
    }
}
