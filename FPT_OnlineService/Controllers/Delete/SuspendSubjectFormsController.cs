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
    public class SuspendSubjectFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuspendSubjectForms
        public ActionResult Index()
        {
            var suspendSubjectForms = db.SuspendSubjectForms.Include(s => s.Form);
            return View(suspendSubjectForms.ToList());
        }

        // GET: SuspendSubjectForms/Details/5
        public ActionResult Details(int? id)
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

        // GET: SuspendSubjectForms/Create
        public ActionResult Create()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: SuspendSubjectForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormID,StudentPhone,SemesterNo,BlockNo,SemesterSeason,SemesterYear")] SuspendSubjectForm suspendSubjectForm)
        {
            if (ModelState.IsValid)
            {
                db.SuspendSubjectForms.Add(suspendSubjectForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSubjectForm.FormID);
            return View(suspendSubjectForm);
        }

        // GET: SuspendSubjectForms/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "FormID,StudentPhone,SemesterNo,BlockNo,SemesterSeason,SemesterYear")] SuspendSubjectForm suspendSubjectForm)
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
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuspendSubjectForm suspendSubjectForm = db.SuspendSubjectForms.Find(id);
            db.SuspendSubjectForms.Remove(suspendSubjectForm);
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
