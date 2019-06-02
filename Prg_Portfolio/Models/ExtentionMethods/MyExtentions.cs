using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ExtentionMethods
{
    public static class MyExtentions
    {
        public static DateTime DateTimeToShamsi(this DateTime dt)
        {

           
            //   DateTime t =new DateTime(oo.GetDayOfMonth((DateTime)dt), oo.GetMonth((DateTime)dt), oo.GetYear((DateTime)dt));
            //return t;

            try
            {
                var dateTime = Convert.ToDateTime(dt);
                PersianCalendar persianCalendar = new PersianCalendar();
                int year = persianCalendar.GetYear(dateTime);
                int month = persianCalendar.GetMonth(dateTime);
                int day = persianCalendar.GetDayOfMonth(dateTime);
                string hour = dateTime.Hour.ToString().PadLeft(2, '0');
                string minute = dateTime.Minute.ToString().PadLeft(2, '0');
                string second = dateTime.Second.ToString().PadLeft(2, '0');
                   DateTime time =new DateTime(year, month, day);
                return time;


            }
            catch
            {

                throw;
            }
        }
    }
}