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
        public ActionResult Index(string sortOrder, string searchString)
        {
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var forms = from f in db.Forms
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                //forms = forms.Where(f => f.StudentName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "type_desc":
                    //forms = forms.OrderByDescending(f => f.StudentName);
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