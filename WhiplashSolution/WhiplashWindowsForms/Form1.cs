using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whiplash.Core;
using Whiplash.Core.CrossCutting;
using Whiplash.Core.Data;
using Whiplash.Core.UI;

namespace WhiplashWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        

        private void btnFindDates_Click(object sender, EventArgs e)
        {
            ContactDTO dto = new ContactDTO();

            dto.RegistrationDate = txtRegistrationDate.Text;

          //  this.Text = dto.ConvertRegistrationToDate().ToString();

            Reminder rm =new Reminder(dto.ConvertRegistrationToDate());
            txtFirstReminder.Text = rm.FirstReminderDate.ToString("dd-MM-yyyy");
            txtSecondReminder.Text = rm.SecondReminderDate.ToString("dd-MM-yyyy");
            txtThirdReminder.Text = rm.ThirdReminderDate.ToString("dd-MM-yyyy");


        }
    }
}
