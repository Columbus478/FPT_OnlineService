using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FPT_OnlineService.Models;

namespace FPT_OnlineService.Controllers
{
    public class CourseRegFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseRegForms
        public ActionResult Index()
        {
            var courseRegForms = db.CourseRegForms.Include(c => c.Form);
            return View(courseRegForms.ToList());
        }

        // GET: CourseRegForms/Details/5
        public ActionResult DetailsCourseReg(int? id)
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
        public ActionResult EditCourseReg(int? id)
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
        public ActionResult EditCourseReg([Bind(Include = "FormID,StudentPhone,SubjectCode,Subject,Status,Class")] CourseRegForm courseRegForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRegForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", courseRegForm.FormID);
            return View(courseRegForm);
        }

        // GET: CourseRegForms/Delete/5
        public ActionResult DeleteCourseReg(int? id)
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
        [HttpPost, ActionName("DeleteCourseReg")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseRegForm courseRegForm = db.CourseRegForms.Find(id);
            db.CourseRegForms.Remove(courseRegForm);
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
