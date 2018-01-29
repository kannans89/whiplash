using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StXavier
{
    //Membership number	Date of Registration	Name	Mail ID	Mobile Number

    public class UserData
    {
        public string MembershipNumber { get; set; }
        public string DateOfRegistration { get; set; }
        public string DateOfExpiration { get; set; }
        public string Name { get; set; }
        public string MailID { get; set; }
        public string MobileNumber { get; set; }
        public string OneMonthBefore { get; set; }
        public string FifteenDaysBefore { get; set; }
        public string OneDayBefore { get; set; }
    }
}
