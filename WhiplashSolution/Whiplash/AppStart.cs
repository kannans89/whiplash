using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Whiplash.Core.CrossCutting;
using Whiplash.Core.UI;

namespace Whiplash
{
    public partial class AppStart : ServiceBase
    {
        private Timer _timer;
        public AppStart()
        {
            InitializeComponent();
           
          
        }

        private double getMilliseconds()
        {
            try
            {
                var milliSecond = ConfigurationManager.AppSettings["timer.interval.milliseconds"];
                return double.Parse(milliSecond);
            }
            catch (Exception ex)
            {
                AppFileLogger.getInstance().Log("App setting file of service (timer.interval.hours)", MessageType.ERROR);
            }
            return 1;
        }

        protected override void OnStart(string[] args)
        {
            
            StartNotificationProcess();

            _timer =new Timer();
            //_timer.Interval = (1*1000*60*60)*_milliseconds;
            _timer.Interval = getMilliseconds();
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            


        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StartNotificationProcess();
        }

        private void StartNotificationProcess()
        {

            try
            {
                AppFileLogger.getInstance().Log("On Start Fired..!!", MessageType.LOG);
                NotificationController controller = new NotificationController();
                controller.SendNotification();
                AppFileLogger.getInstance().Log("end of on ..!!", MessageType.LOG);
            }
            catch (Exception ex)
            {
                try
                {
                    AppFileLogger.getInstance().Log(ex.Message, MessageType.ERROR);
                }
                catch (Exception innerEx)
                {

                    var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ERROR.txt");
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(innerEx.Message);
                    sw.Flush();
                    sw.Close();

                }

            }
        }

        protected override void OnStop()
        {
            _timer.Enabled = false;
        }
    }
}
