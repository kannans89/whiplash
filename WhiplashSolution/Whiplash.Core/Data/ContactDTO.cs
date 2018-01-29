using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiplash.Core.Data
{
    public class ContactDTO
    {
        private string v;

        public ContactDTO()
        {
        }

        public ContactDTO(string contactCSV)
        {
            if (contactCSV == "")
                return;
            string[] contactInfo = contactCSV.Split(',');
            this.Id = contactInfo[0];
            this.Name = contactInfo[1];
            this.MobileNo = contactInfo[2];
            this.Email = contactInfo[3];
            this.RegistrationDate = contactInfo[4];
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string RegistrationDate { get; set; }

        public DateTime ConvertRegistrationToDate()
        {
            String stringDate = RegistrationDate;
            string[] splittedDate = stringDate.Split('-');
            int day = int.Parse(splittedDate[0]);
            int month = int.Parse(splittedDate[1]);
            int year = int.Parse(splittedDate[2]);

            return new DateTime(year, month, day);

        }
    }
}
