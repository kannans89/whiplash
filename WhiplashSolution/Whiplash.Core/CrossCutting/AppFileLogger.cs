using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiplash.Core.CrossCutting
{
    public enum MessageType
    {
        WARNING,ERROR ,LOG
    }

    public class AppFileLogger : ILogger
    {

        private static AppFileLogger _singletonLogger ;

        private AppFileLogger()
        {
        }

        public static AppFileLogger getInstance()
        {
            if(_singletonLogger == null)
                _singletonLogger =new AppFileLogger();

            return _singletonLogger;
        }


        public async void Log(string msg,MessageType type)
        {

            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LOGS.txt",true))
            {

                await sw.WriteLineAsync(getFromattedHeading(type, "Start"));
                await sw.WriteLineAsync(msg);
                await sw.WriteLineAsync(getFromattedHeading(type, "End"));
            }

        }

        private string getFromattedHeading(MessageType type,string startOrEnd)
        {
            StringBuilder heading = new StringBuilder();
            heading.Append(type.ToString())
                .Append(": ")
                .Append(startOrEnd)
                .Append("-->")
                .Append(DateTime.Now);
                    

            return heading.ToString();

        }
    }
}
