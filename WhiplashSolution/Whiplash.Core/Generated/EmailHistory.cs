using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiplash.Core.Generated
{
   public class EmailHistory
   {
         private int _reminders;
         public string Name { get; set; }
         public string ContactID { get; set; }
         public DateTime LastEmailSent { get; set; }
         public int TotalReminders {
             get { return _reminders; }
             set { _reminders = value; }
         }

    }
}
