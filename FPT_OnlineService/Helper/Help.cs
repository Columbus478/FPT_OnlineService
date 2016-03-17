using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPT_OnlineService.Helper
{
    public class Help
    {
        public static string GetFormDate(DateTime item)
        {
            DateTime today = DateTime.Now;
            string date = "";
            if (item.Date.Year.Equals(today.Date.Year))
            {
                if (item.Date.Month.Equals(today.Month))
                {
                    if (item.Date.Day.Equals(today.Day))
                    {
                        date = item.Date.ToString("HH:MM tt");
                    }
                    else
                    {
                        date = item.Date.ToString("M");
                    }
                }
                else
                {
                    date = item.Date.ToString("M");
                }
            }
            else
            {
                date = item.Date.Month + " " + item.Date.Year;
            }
            return date;
        }
    }
}