using FPT_OnlineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace FPT_OnlineService.Controllers
{
    public class StaffController : Controller
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
                forms = forms.Where(f => f.RollNo.Contains(searchString));
            }
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

        public ActionResult Approved()
        {
            return View();
        }

        public ActionResult Rejected()
        {
            return View();
        }

        public ActionResult InProgress()
        {
            return View();
        }

        //Form Details
        /*
        public ActionResult Staff(int? id)
        {

            retutn false;
        }
         * */
        // GET: SuspendSemesterForms/Edit/5
        public ActionResult StaffEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendSemesterForm suspendSemesterForm = db.SuspendSemesterForms.Find(id);
            if (suspendSemesterForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSemesterForm.FormID);
            return View(suspendSemesterForm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StaffEndorsement([Bind(Include = "FormID,PreviousSemester,TwoPrevSemester")] SuspendSemesterForm suspendSemesterForm, string FormStatus,string isWeekBefore)
        {
            SuspendSemesterForm ssf = db.SuspendSemesterForms.Find(suspendSemesterForm.FormID);
            Form f = db.Forms.Find(suspendSemesterForm.FormID);
            f.Status = FormStatus;
            if(isWeekBefore.Equals("on"))
                f.isWeekBefore = "True";
            else
                f.isWeekBefore = "False";
            ssf.PreviousSemester = suspendSemesterForm.PreviousSemester;
            ssf.TwoPrevSemester = suspendSemesterForm.TwoPrevSemester;
            db.Entry(ssf).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Staff");
        }
    }
}