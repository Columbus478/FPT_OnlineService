using FPT_OnlineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using FPT_OnlineService.DAL;

namespace FPT_OnlineService.Controllers
{
    public class FormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Forms
        public ActionResult Index()
        {
            var courseRegForms = db.CourseRegForms.Include(c => c.Form);
            return View(courseRegForms.ToList());
        }

        // GET: Forms/Details/5
        public ActionResult Details(int? id)
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
                    return RedirectToAction("CourseRegDetails", new { id = id });
                case ("Suspend Subject"):
                    return RedirectToAction("SuspendSubjectDetails", new { id = id });
                case ("Suspend Semester"):
                    return RedirectToAction("SuspendSemesterDetails", new { id = id });
                case ("Drop Out"):
                    return RedirectToAction("DropOutDetails", new { id = id });
                case ("General Request"):
                    return RedirectToAction("RequestDetails", new { id = id });
                /*
            case (""):
                break;*/
                default:
                    break;
            }
            return View();
        }

        //Edit Form
        public ActionResult Edit(int id)
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
                    return RedirectToAction("CourseRegEdit", new { id = id });
                case ("Suspend Subject"):
                    return RedirectToAction("SuspendSubjectEdit", new { id = id });
                case ("Suspend Semester"):
                    return RedirectToAction("SuspendSemesterEdit", new { id = id });
                case ("Drop Out"):
                    return RedirectToAction("DropOutEdit", new { id = id });
                case ("General Request"):
                    return RedirectToAction("RequestEdit", new { id = id });
                /*
            case (""):
                break;*/
                default:
                    break;
            }
            return View();
        }

        // GET: CourseRegForms/Create
        public ActionResult CourseRegCreate()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: CourseRegForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseRegCreate([Bind(Include = "StudentPhone,SubjectCode,Subject,Status,Class")] CourseRegForm courseRegForm)
        {
            if (ModelState.IsValid)
            {
                Form form = new Form();
                form.Type = "Course Registration";
                form.Date = DateTime.Now;
                form.CurrentDesk = "Academic Staff";
                form.Flow = "AcademicStaff,";
                form.RollNo = UserInfo.Username;
                form.Status = "New";
                db.Forms.Add(form);
                db.SaveChanges();
                courseRegForm.FormID = form.ID;
                db.CourseRegForms.Add(courseRegForm);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", courseRegForm.FormID);
            return View(courseRegForm);
        }

        // GET: CourseRegForms/Details/5
        public ActionResult CourseRegDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegForm courseRegForm = db.CourseRegForms.Find(id);
            if (courseRegForm == null)
            {
                return HttpNotFound();
            }
            return View(courseRegForm);
        }

        // GET: CourseRegForms/Edit/5
        public ActionResult CourseRegEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegForm courseRegForm = db.CourseRegForms.Find(id);
            if (courseRegForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", courseRegForm.FormID);
            return View(courseRegForm);
        }

        // POST: CourseRegForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseRegEdit([Bind(Include = "FormID,StudentPhone,SubjectCode,Subject")] CourseRegForm courseRegForm)
        {
            if (ModelState.IsValid)
            {
                CourseRegForm crf = db.CourseRegForms.Find(courseRegForm.FormID);
                crf.StudentPhone = courseRegForm.StudentPhone;
                crf.SubjectCode = courseRegForm.SubjectCode;
                db.Entry(crf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", courseRegForm.FormID);
            return View(courseRegForm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StaffEndorsement([Bind(Include = "FormID,PreviousSemester,TwoPrevSemester")] SuspendSemesterForm suspendSemesterForm)
        {
            if (ModelState.IsValid)
            {
                SuspendSemesterForm ssf = db.SuspendSemesterForms.Find(suspendSemesterForm.FormID);
                ssf.PreviousSemester = suspendSemesterForm.PreviousSemester;
                ssf.TwoPrevSemester = suspendSemesterForm.TwoPrevSemester;
                db.Entry(ssf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSemesterForm.FormID);
            return View(suspendSemesterForm);
        }

        // GET: CourseRegForms/Delete/5
        public ActionResult CourseRegDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegForm courseRegForm = db.CourseRegForms.Find(id);
            if (courseRegForm == null)
            {
                return HttpNotFound();
            }
            return View(courseRegForm);
        }

        // POST: CourseRegForms/Delete/5
        [HttpPost, ActionName("CourseRegDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseRegForm courseRegForm = db.CourseRegForms.Find(id);
            db.CourseRegForms.Remove(courseRegForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: SuspendSubjectForms/Details/5
        public ActionResult SuspendSubjectDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendSubjectForm suspendSubjectForm = db.SuspendSubjectForms.Find(id);
            if (suspendSubjectForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSubjectForm.FormID);
            return View(suspendSubjectForm);
        }

        // GET: SuspendSubjectForms/Create
        public ActionResult SuspendSubjectCreate()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: SuspendSubjectForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSubjectCreate([Bind(Include = "StudentPhone,SemesterSeason,SubjectCode,SubjectName")] SuspendSubjectForm suspendSubjectForm)
        {
            if (ModelState.IsValid)
            {
                Form form = new Form();
                form.Type = "Suspend Subject";
                form.Date = DateTime.Now;
                form.CurrentDesk = "Academic Staff";
                form.Flow = "AcademicStaff,";
                form.RollNo = UserInfo.Username;
                form.Status = "New";
                db.Forms.Add(form);
                db.SaveChanges();
                suspendSubjectForm.FormID = form.ID;
                db.SuspendSubjectForms.Add(suspendSubjectForm);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSubjectForm.FormID);
            return View(suspendSubjectForm);
        }

        // GET: SuspendSubjectForms/Edit/5
        public ActionResult SuspendSubjectEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendSubjectForm suspendSubjectForm = db.SuspendSubjectForms.Find(id);
            if (suspendSubjectForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSubjectForm.FormID);
            return View(suspendSubjectForm);
        }

        // POST: SuspendSubjectForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSubjectEdit([Bind(Include = "FormID,StudentPhone,SemesterNo,BlockNo,SemesterSeason,SemesterYear")] SuspendSubjectForm suspendSubjectForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspendSubjectForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSubjectForm.FormID);
            return View(suspendSubjectForm);
        }

        // GET: SuspendSubjectForms/Delete/5
        public ActionResult SuspendSubjectDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendSubjectForm suspendSubjectForm = db.SuspendSubjectForms.Find(id);
            if (suspendSubjectForm == null)
            {
                return HttpNotFound();
            }
            return View(suspendSubjectForm);
        }

        // POST: SuspendSubjectForms/Delete/5
        [HttpPost, ActionName("SuspendSubjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSubjectDeleteConfirmed(int id)
        {
            SuspendSubjectForm suspendSubjectForm = db.SuspendSubjectForms.Find(id);
            db.SuspendSubjectForms.Remove(suspendSubjectForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: SuspendSemesterForms/Details/5
        public ActionResult SuspendSemesterDetails(int? id)
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
            return View(suspendSemesterForm);
        }

        // GET: SuspendSemesterForms/Create
        public ActionResult SuspendSemesterCreate()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: SuspendSemesterForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSemesterCreate([Bind(Include = "StudentPhone,SemesterSeason,SemesterYear")] SuspendSemesterForm suspendSemesterForm)
        {
            if (ModelState.IsValid)
            {
                Form form = new Form();
                form.Type = "Suspend Semester";
                form.Date = DateTime.Now;
                form.CurrentDesk = "Academic Staff";
                form.Flow = "AcademicStaff,";
                form.RollNo = UserInfo.Username;
                form.Status = "New";
                db.Forms.Add(form);
                db.SaveChanges();
                suspendSemesterForm.FormID = form.ID;
                db.SuspendSemesterForms.Add(suspendSemesterForm);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSemesterForm.FormID);
            return View(suspendSemesterForm);
        }

        // GET: SuspendSemesterForms/Edit/5
        public ActionResult SuspendSemesterEdit(int? id)
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

        // POST: SuspendSemesterForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSemesterEdit([Bind(Include = "FormID,StudentPhone,SemesterNo,SemesterSeason,SemesterYear")] SuspendSemesterForm suspendSemesterForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspendSemesterForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSemesterForm.FormID);
            return View(suspendSemesterForm);
        }

        // GET: SuspendSemesterForms/Delete/5
        public ActionResult SuspendSemesterDelete(int? id)
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
            return View(suspendSemesterForm);
        }

        // POST: SuspendSemesterForms/Delete/5
        [HttpPost, ActionName("SuspendSemesterDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendSemesterDeleteConfirmed(int id)
        {
            SuspendSemesterForm suspendSemesterForm = db.SuspendSemesterForms.Find(id);
            db.SuspendSemesterForms.Remove(suspendSemesterForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: RequestForms/Details/5
        public ActionResult RequestDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.RequestForms.Find(id);
            if (requestForm == null)
            {
                return HttpNotFound();
            }
            return View(requestForm);
        }

        // GET: RequestForms/Create
        public ActionResult RequestCreate()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: RequestForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestCreate([Bind(Include = "RequestTitle,StudentPhone,Class,Description")] RequestForm requestForm)
        {
            if (ModelState.IsValid)
            {
                Form form = new Form();
                form.Type = "General Request";
                form.Date = DateTime.Now;
                form.CurrentDesk = "Academic Staff";
                form.Flow = "AcademicStaff,";
                form.RollNo = UserInfo.Username;
                form.Status = "New";
                db.Forms.Add(form);
                db.SaveChanges();
                requestForm.FormID = form.ID;
                db.RequestForms.Add(requestForm);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", requestForm.FormID);
            return View(requestForm);
        }

        // GET: RequestForms/Edit/5
        public ActionResult RequestEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.RequestForms.Find(id);
            if (requestForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", requestForm.FormID);
            return View(requestForm);
        }

        // POST: RequestForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestEdit([Bind(Include = "FormID,RequestTitle,StudentPhone,StudentEmail,Class,Batch,Description")] RequestForm requestForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", requestForm.FormID);
            return View(requestForm);
        }

        // GET: RequestForms/Delete/5
        public ActionResult RequestDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.RequestForms.Find(id);
            if (requestForm == null)
            {
                return HttpNotFound();
            }
            return View(requestForm);
        }

        // POST: RequestForms/Delete/5
        [HttpPost, ActionName("RequestDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RequestDeleteConfirmed(int id)
        {
            RequestForm requestForm = db.RequestForms.Find(id);
            db.RequestForms.Remove(requestForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DropOutForms/Details/5
        public ActionResult DropOutDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropOutForm dropOutForm = db.DropOutForms.Find(id);
            if (dropOutForm == null)
            {
                return HttpNotFound();
            }
            return View(dropOutForm);
        }

        // GET: DropOutForms/Create
        public ActionResult DropOutCreate()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: DropOutForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropOutCreate([Bind(Include = "Class,MethodPayment,DropOutDate,Reason")] DropOutForm dropOutForm)
        {
            if (ModelState.IsValid)
            {
                Form form = new Form();
                form.Type = "Drop Out";
                form.Date = DateTime.Now;
                form.CurrentDesk = "Academic Staff";
                form.Flow = "AcademicStaff,";
                form.RollNo = UserInfo.Username;
                form.Status = "New";
                db.Forms.Add(form);
                db.SaveChanges();
                dropOutForm.FormID = form.ID;
                db.DropOutForms.Add(dropOutForm);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", dropOutForm.FormID);
            return View(dropOutForm);
        }

        // GET: DropOutForms/Edit/5
        public ActionResult DropOutEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropOutForm dropOutForm = db.DropOutForms.Find(id);
            if (dropOutForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", dropOutForm.FormID);
            return View(dropOutForm);
        }

        // POST: DropOutForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropOutEdit([Bind(Include = "FormID,Class,MethodPayment,DropOutDate,Reason")] DropOutForm dropOutForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dropOutForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", dropOutForm.FormID);
            return View(dropOutForm);
        }

        // GET: DropOutForms/Delete/5
        public ActionResult DropOutDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropOutForm dropOutForm = db.DropOutForms.Find(id);
            if (dropOutForm == null)
            {
                return HttpNotFound();
            }
            return View(dropOutForm);
        }

        // POST: DropOutForms/Delete/5
        [HttpPost, ActionName("DropOutDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DropOutDeleteConfirmed(int id)
        {
            DropOutForm dropOutForm = db.DropOutForms.Find(id);
            db.DropOutForms.Remove(dropOutForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}