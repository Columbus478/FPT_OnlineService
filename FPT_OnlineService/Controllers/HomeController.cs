﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_OnlineService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string role = "";
            if (!string.IsNullOrEmpty(FPT_OnlineService.Models.User.UserRole))
                role = FPT_OnlineService.Models.User.UserRole;
            if(User.IsInRole("FPT-Staff") || role.Equals("FPT-Staff"))
                return RedirectToAction("Index", "Staff");
            else if (User.IsInRole("Student") || role.Equals("Student"))
                return RedirectToAction("Index", "Student");
            else
                return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}