using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPT_OnlineService.Models;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace FPT_OnlineService.Helper
{
    public class Help
    {
        public static string GetDate(DateTime item)
        {
            DateTime today = DateTime.Now;
            string date = "";
            if (item.Date.Year.Equals(today.Date.Year))
            {
                if (item.Date.Month.Equals(today.Month))
                {
                    if (item.Date.Day.Equals(today.Day))
                    {
                        date = item.Date.ToString("hh:mm tt");
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
                date = item.Date.ToString("M") + " " + item.Date.Year;
            }
            return date;
        }

        public static string GetCurrentDesk(int roleId)
        {
            switch (roleId)
            {
                case 4:
                    return "HeadOfAcademicDepartment-Staff";
                case 5:
                    return "AcademicHead-Staff";
                case 6:
                    return "CampusDirector-Staff";
                case 7:
                    return "AcademicStaff-Staff";
                default:
                    return "AcademicStaff-Staff";
            }
        }


        public static string GetRoleId(string CurrentDesk)
        {
            switch (CurrentDesk)
            {
                case "HeadOfAcademicDepartment-Staff":
                    return "4";
                case "AcademicHead-Staff":
                    return "5";
                case "CampusDirector-Staff":
                    return "6";
                case "Academic-Staff":
                    return "7";
                default:
                    return "7";
            }
        }
    }
}