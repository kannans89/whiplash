using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiplash.Core.Data
{
    public class CSVReader
    {
        private IList<ContactDTO> _contacts;

        public CSVReader()
        {
            _contacts = new List<ContactDTO>();
        }

        public IEnumerable<ContactDTO> Read()
        {
            using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Upload\\Contact.csv"))
            {
                string line = sr.ReadLine();
                while (line!=null)
                {
                    _contacts.Add(new ContactDTO(line));
                     line = sr.ReadLine();
                }

            }

            return _contacts;
        }

    }
}
