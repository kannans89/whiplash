using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceApp
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {

                var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt");
                sw.WriteLine("hi...");
                sw.WriteLine(DateTime.Now);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
            }

        }

        protected override void OnStop()
        {
        }
    }
}
