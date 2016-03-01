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
    public class DropOutFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DropOutForms
        public ActionResult Index()
        {
            var dropOutForms = db.DropOutForms.Include(d => d.Form);
            return View(dropOutForms.ToList());
        }

        // GET: DropOutForms/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create()
        {
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type");
            return View();
        }

        // POST: DropOutForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormID,Class,MethodPayment,DropOutDate,Reason")] DropOutForm dropOutForm)
        {
            if (ModelState.IsValid)
            {
                db.DropOutForms.Add(dropOutForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", dropOutForm.FormID);
            return View(dropOutForm);
        }

        // GET: DropOutForms/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "FormID,Class,MethodPayment,DropOutDate,Reason")] DropOutForm dropOutForm)
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
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
