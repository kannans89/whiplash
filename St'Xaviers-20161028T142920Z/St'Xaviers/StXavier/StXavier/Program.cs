using CsvReader;
using DbHelper;
using MailerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StXavier
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"d:\Sample Data.csv";
            Reader reader = new Reader();
            DataTable dt = reader.Read(filePath);
            List<UserData> list = Helper.ConvertToList<UserData>(dt);
            List<UserData> updatedList = new List<UserData>();

            foreach (var item in list)
            {
                DateTime dateReg = DateTime.Parse(item.DateOfRegistration);
                DateTime dateExp = dateReg.AddYears(1);

                DateTime TodaysDate = DateTime.Now;

                int month = dateExp.Month;

                double differenceInDays = dateExp.Subtract(TodaysDate).Days;

                double LastMonth = dateExp.Month - 1;

                string[] oddMonths = { "1", "3", "5", "7", "8", "10", "12" };

                if ((oddMonths.Contains(month.ToString()) && differenceInDays <= 31) || (!oddMonths.Contains(month.ToString()) && differenceInDays <= 30) || (month == 2 && (differenceInDays <= 28 || differenceInDays <= 29)))
                {
                    if (item.OneMonthBefore != "Yes")
                    {
                        try
                        {
                            ClassMailer.SendExpiryMail(item.MailID, item.DateOfRegistration, dateExp.ToString("dd/MM/yyyy"), item.Name, item.MobileNumber, "SendMailBeforeOneMonth.html",item.MembershipNumber);
                            item.OneMonthBefore = "Yes";
                        }
                        catch (Exception e)
                        {
                            item.OneMonthBefore = "No";
                        }
                    }
                }
                else if (differenceInDays <= 7)
                {
                    if (item.FifteenDaysBefore != "Yes")
                    {
                        try
                        {
                            ClassMailer.SendExpiryMail(item.MailID, item.DateOfRegistration, dateExp.ToString("dd/MM/yyyy"), item.Name, item.MobileNumber, "SendMailBeforeOneWeek.html", item.MembershipNumber);
                            item.FifteenDaysBefore = "Yes";
                        }
                        catch (Exception e)
                        {
                            item.FifteenDaysBefore = "No";
                        }
                    }
                }
                else if (differenceInDays <= 0)
                {
                    if (item.OneDayBefore != "Yes")
                    {
                        try
                        {
                            ClassMailer.SendExpiryMail(item.MailID, item.DateOfRegistration, dateExp.ToString("dd/MM/yyyy"), item.Name, item.MobileNumber, "SendMailBeforeOneDay.html", item.MembershipNumber);
                            item.OneDayBefore = "Yes";
                        }
                        catch (Exception e)
                        {
                            item.OneDayBefore = "No";
                        }
                    }
                }
                updatedList.Add(item);
            }

            string updatedCSVData = Writer.CreateCSVTextFile(updatedList);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                File.AppendAllText(filePath, updatedCSVData);
            }

        }
    }
}