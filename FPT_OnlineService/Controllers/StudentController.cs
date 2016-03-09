using FPT_OnlineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FPT_OnlineService.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET All Forms
        public ActionResult Index(string sortOrder)
        {
            string id = User.Identity.GetUserId();
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var forms = from f in db.Forms
                        select f;

            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderBy(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderBy(f => f.Date);
                    break;
            }
            return View(forms.ToList());
        }

        public ActionResult Drafts()
        {
            return View();
        }

        public ActionResult Trash()
        {
            return View();
        }

        public ActionResult Approved(string sortOrder)
        {
            string id = User.Identity.GetUserId();
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var forms = from f in db.Forms
                        select f;

            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderBy(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderBy(f => f.Date);
                    break;
            }
            return View(forms.ToList());
        }

        public ActionResult Rejected(string sortOrder)
        {
            string id = User.Identity.GetUserId();
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var forms = from f in db.Forms
                        select f;

            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderBy(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderBy(f => f.Date);
                    break;
            }
            return View(forms.ToList());
        }

        public ActionResult InProgress(string sortOrder)
        {
            string id = User.Identity.GetUserId();
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var forms = from f in db.Forms
                        select f;

            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderBy(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderBy(f => f.Date);
                    break;
            }
            return View(forms.ToList());
        }

        public ActionResult New(string sortOrder)
        {
            string id = User.Identity.GetUserId();
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var forms = from f in db.Forms
                        select f;

            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderBy(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderBy(f => f.Date);
                    break;
            }
            return View(forms.ToList());
        }
    }
}