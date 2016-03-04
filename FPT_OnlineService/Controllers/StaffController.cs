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
        public ActionResult StaffEndorsement(int? id)
        {

            return
        }
         * */
        // GET: SuspendSemesterForms/Edit/5


        public ActionResult StaffEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //string formType = CheckFormType(id);
            Form form = db.Forms.Find(id);
            string formType = form.Type;

            switch (formType)
            {
                case ("Course Registration"):
                    return RedirectToAction("CourseRegEndorsement", new { id = id });
                case ("Suspend Subject"):
                    return RedirectToAction("SuspendSubjectEndorsement", new { id = id });
                case ("Suspend Semester"):
                    return RedirectToAction("SuspendSemesterEndorsement", new { id = id });
                case ("Drop Out"):
                    return RedirectToAction("DropOutEndorsement", new { id = id });
                case ("General Request"):
                    return RedirectToAction("RequestEndorsement", new { id = id });
                /*
            case (""):
                break;*/
                default:
                    break;
            }
            return View();
        }

        public ActionResult SuspendSemesterEndorsement(int? id)
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
        public ActionResult SuspendSemesterEndorsement([Bind(Include = "FormID,PreviousSemester,TwoPrevSemester")] SuspendSemesterForm suspendSemesterForm, string FormStatus, string isWeekBefore, string TuitionFee)
        {
            SuspendSemesterForm ssf = db.SuspendSemesterForms.Find(suspendSemesterForm.FormID);
            Form f = db.Forms.Find(suspendSemesterForm.FormID);
            f.Status = FormStatus;
            if (isWeekBefore.Equals("on"))
                f.isWeekBefore = "True";
            else
                f.isWeekBefore = "False";
            f.ApprovedBy = DAL.UserInfo.Name;

            if (TuitionFee.Equals("on"))
                ssf.TuitionFee = "True";
            else
                ssf.TuitionFee = "False";
            ssf.PreviousSemester = suspendSemesterForm.PreviousSemester;
            ssf.TwoPrevSemester = suspendSemesterForm.TwoPrevSemester;
            db.Entry(ssf).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Staff");
        }
    }
}