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
    public class RequestFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RequestForms
        public ActionResult Index()
        {
            var requestForms = db.RequestForms.Include(r => r.Form);
            return View(requestForms.ToList());
        }

        // GET: RequestForms/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: RequestForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormID,RequestTitle,StudentPhone,StudentEmail,Class,Batch")] RequestForm requestForm)
        {
            if (ModelState.IsValid)
            {
                db.RequestForms.Add(requestForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", requestForm.FormID);
            return View(requestForm);
        }

        // GET: RequestForms/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "FormID,RequestTitle,StudentPhone,StudentEmail,Class,Batch")] RequestForm requestForm)
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
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestForm requestForm = db.RequestForms.Find(id);
            db.RequestForms.Remove(requestForm);
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
