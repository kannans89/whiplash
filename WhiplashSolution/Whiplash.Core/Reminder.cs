using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiplash.Core
{
    public enum OccuranceType
    {
        LAST_DAY, BEFORE_WEEK, BEFORE_MONTH , NA 
    }

    
    public class Reminder
    {
        private DateTime _registrationDate;
        private OccuranceType _occurance;

        public Reminder()
        {
            _occurance =OccuranceType.NA;
        }

        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }

        }

        public Reminder(DateTime registrationDate)
        {
            _registrationDate = registrationDate;
        }

        public int GetDaysOfAnyYear(int year)
        {
            var thisYear = new DateTime(year,1,1);
            var nextyear = new DateTime(year+1,1,1);
            return (nextyear - thisYear).Days;
        }

        public DateTime FirstReminderDate
        {
            get
            {

              // return _registrationDate.AddMonths(11);
                return ThirdReminderDate.AddDays(-30);

            }

        }

       public DateTime SecondReminderDate
        {
            get
            {
                //return _registrationDate
                //           .AddMonths(12)
                //           .AddDays(-7);

                
                return ThirdReminderDate.AddDays(-7);

            }

        }


        public DateTime ThirdReminderDate
        {

            get
            {
                // return _registrationDate.AddMonths(12);
                var year = _registrationDate.Year;
                var days = GetDaysOfAnyYear(year);
                return _registrationDate.AddDays(days);
            }
        }


        public bool HasExpiryDateApproaching()
        {


            return DateTime.Today.Equals(FirstReminderDate) ||
                   DateTime.Today.Equals(SecondReminderDate) ||
                   DateTime.Today.Equals(ThirdReminderDate);


        }

        public OccuranceType FindOccuranceType()
        {
            if(DateTime.Today.Equals(FirstReminderDate))
                _occurance = OccuranceType.BEFORE_MONTH;
           else if(DateTime.Today.Equals(SecondReminderDate))
                _occurance = OccuranceType.BEFORE_WEEK;
            else if(DateTime.Today.Equals(ThirdReminderDate))
                _occurance = OccuranceType.LAST_DAY;
            return _occurance;


        }

    }
}
