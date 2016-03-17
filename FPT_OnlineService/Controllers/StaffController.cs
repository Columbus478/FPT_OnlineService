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
using PagedList;

namespace FPT_OnlineService.Controllers
{
    [Authorize(Roles = "FPT-Staff")]
    public class StaffController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET All Forms
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
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
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult New(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; 
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
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Approved(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
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
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Rejected(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; 
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
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult InProgress(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; 
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
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

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

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (suspendSemesterForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSemesterForm.FormID);
            return View(suspendSemesterForm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSemesterEndorsement([Bind(Include = "FormID,Status,PreviousSemester,TwoPrevSemester")] SuspendSemesterForm suspendSemesterForm, string IsWeekBefore, string FormStatus, string TuitionFee)
        {
            SuspendSemesterForm ssf = db.SuspendSemesterForms.Find(suspendSemesterForm.FormID);
            Form f = db.Forms.Find(suspendSemesterForm.FormID);
            f.Status = FormStatus;
            if (IsWeekBefore.Equals("on"))
                f.IsWeekBefore = true;
            else
                f.IsWeekBefore = false;
            f.EndorsedBy = DAL.UserInfo.Name;
            if (f.Status.Equals("Approved"))
                f.ApprovalDate = DateTime.Now.ToString();

            if (TuitionFee.Equals("true"))
                ssf.TuitionFee = true;
            else
                ssf.TuitionFee = false;
            ssf.PreviousSemester = suspendSemesterForm.PreviousSemester;
            ssf.TwoPrevSemester = suspendSemesterForm.TwoPrevSemester;
            db.Entry(ssf).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }

        
        public ActionResult SuspendSubjectEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendSubjectForm suspendSubjectForm = db.SuspendSubjectForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };


            if (suspendSubjectForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSubjectForm.FormID);
            return View(suspendSubjectForm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSubjectEndorsement([Bind(Include = "FormID")] SuspendSubjectForm suspendSubjectForm, string FormStatus, string IsWeekBefore, string NotAllSubject)
        {
            SuspendSubjectForm ssf = db.SuspendSubjectForms.Find(suspendSubjectForm.FormID);
            Form f = db.Forms.Find(suspendSubjectForm.FormID);
            f.Status = FormStatus;
            if (IsWeekBefore.Equals("on"))
                f.IsWeekBefore = true;
            else
                f.IsWeekBefore = false;
            f.EndorsedBy = DAL.UserInfo.Name;
            if (f.Status.Equals("Approved"))
                f.ApprovalDate = DateTime.Now.ToString();

            if (NotAllSubject.Equals("true"))
                ssf.NotAllSubject = true;
            else
                ssf.NotAllSubject = false;
            db.Entry(ssf).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }

        public ActionResult CourseRegEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegForm courseRegForm = db.CourseRegForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (courseRegForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", courseRegForm.FormID);
            return View(courseRegForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseRegEndorsement([Bind(Include = "FormID")] CourseRegForm courseRegForm, string FormStatus, string IsWeekBefore, List<string> CoursesAvailable, string TuitionFee)
        {
            CourseRegForm crf = db.CourseRegForms.Find(courseRegForm.FormID);
            Form f = db.Forms.Find(courseRegForm.FormID);
            f.Status = FormStatus;
            if (IsWeekBefore.Equals("on"))
                f.IsWeekBefore = true;
            else
                f.IsWeekBefore = false;
            f.EndorsedBy = DAL.UserInfo.Name;
            f.EndorsedBy = DAL.UserInfo.Name;
            if (f.Status.Equals("Approved"))
                f.ApprovalDate = DateTime.Now.ToString();

            if (TuitionFee.Equals("true"))
                crf.TuitionFee = true;
            else
                crf.TuitionFee = false;

            db.Entry(crf).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }

        public ActionResult DropOutEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropOutForm dropOutForm = db.DropOutForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (dropOutForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", dropOutForm.FormID);
            return View(dropOutForm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropOutEndorsement([Bind(Include = "FormID")] DropOutForm dropOutForm, string FormStatus, string IsWeekBefore, 
            string TuitionFee, string AcademicHeadEndorse, string AccountStatus, string LibraryStatus)
        {
            DropOutForm dof = db.DropOutForms.Find(dropOutForm.FormID);
            Form f = db.Forms.Find(dropOutForm.FormID);
            f.Status = FormStatus;
            if (IsWeekBefore.Equals("on"))
                f.IsWeekBefore = true;
            else
                f.IsWeekBefore = false;
            f.EndorsedBy = DAL.UserInfo.Name;
            if (f.Status.Equals("Approved"))
                f.ApprovalDate = DateTime.Now.ToString();
            dof.AcademicHeadEndorse = AcademicHeadEndorse;
            dof.AccountStatus = AccountStatus;
            dof.LibraryStatus = LibraryStatus;

            if (f.Status.Equals("Approved"))
                f.ApprovalDate = DateTime.Now.ToString();

            db.Entry(dof).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }

        public ActionResult Drafts()
        {
            return View();
        }
        
        public ActionResult Trash()
        {
            return View();
        }

        public ActionResult RequestEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.RequestForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (requestForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", requestForm.FormID);
            return View(requestForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestEndorsement([Bind(Include = "FormID")] RequestForm requestForm, 
            string FormStatus, string IsWeekBefore, string ReceivedBy, string ToDepartment,
            string ProcessedBy,string ApprovalReason)
        {
            RequestForm rf = db.RequestForms.Find(requestForm.FormID);
            Form f = db.Forms.Find(requestForm.FormID);
            rf.ReceivedBy = ReceivedBy;
            rf.ProcessedBy = ProcessedBy;
            rf.ToDepartment = ToDepartment;
            f.Status = FormStatus;
            if (IsWeekBefore.Equals("on"))
                f.IsWeekBefore = true;
            else
                f.IsWeekBefore = false;
            f.EndorsedBy = DAL.UserInfo.Name;
            if (f.Status.Equals("Approved"))
                f.ApprovalDate = DateTime.Now.ToString();
            rf.ApprovalReason = ApprovalReason;

            db.Entry(rf).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }


        // GET: Semesters
        public ActionResult Semester()
        {
            return View(db.Semesters.ToList());
        }

        // GET: Semesters/Details/5
        public ActionResult SemesterDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // GET: Semesters/Create
        public ActionResult CreateSemester()
        {
            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSemester([Bind(Include = "StartDate,EndDate,Year,NoOfWeeks,NoOfMonths,Season")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                semester.Name = semester.Season+" " + semester.Year;
                db.Semesters.Add(semester);
                db.SaveChanges();
                return RedirectToAction("Semester");
            }

            return View(semester);
        }

        // GET: Semesters/Edit/5
        public ActionResult EditSemester(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSemester([Bind(Include = "StartDate,EndDate,Year,NoOfWeeks,NoOfMonths,Season")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                semester.Name = semester.Season + " " + semester.Year;
                db.Entry(semester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Semester");
            }
            return View(semester);
        }

        // GET: Semesters/Delete/5
        public ActionResult DeleteSemester(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("DeleteSemester")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Semester semester = db.Semesters.Find(id);
            db.Semesters.Remove(semester);
            db.SaveChanges();
            return RedirectToAction("Semester");
        }


        public ActionResult Notifications()
        {
            var notifications = db.Notifications.Include(n => n.Form).Include(n => n.Staff).Include(n => n.Student);
            return View(notifications.ToList());
        }
        
    }
}