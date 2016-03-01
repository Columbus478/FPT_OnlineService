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
    public class SuspendSemesterFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuspendSemesterForms
        public ActionResult Index()
        {
            var suspendSemesterForms = db.SuspendSemesterForms.Include(s => s.Form);
            return View(suspendSemesterForms.ToList());
        }

        // GET: SuspendSemesterForms/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: SuspendSemesterForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormID,StudentPhone,SemesterNo,SemesterSeason,SemesterYear")] SuspendSemesterForm suspendSemesterForm)
        {
            if (ModelState.IsValid)
            {
                db.SuspendSemesterForms.Add(suspendSemesterForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSemesterForm.FormID);
            return View(suspendSemesterForm);
        }

        // GET: SuspendSemesterForms/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "FormID,StudentPhone,SemesterNo,SemesterSeason,SemesterYear")] SuspendSemesterForm suspendSemesterForm)
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
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuspendSemesterForm suspendSemesterForm = db.SuspendSemesterForms.Find(id);
            db.SuspendSemesterForms.Remove(suspendSemesterForm);
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
