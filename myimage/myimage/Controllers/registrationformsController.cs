using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using myimage.Models;

namespace myimage.Controllers
{
    public class registrationformsController : Controller
    {
        private myimagedatabaseEntities db = new myimagedatabaseEntities();

        // GET: registrationforms
        public ActionResult Index()
        {
            var registrationforms = db.registrationforms.Include(r => r.signin);
            return View(registrationforms.ToList());
        }

        // GET: registrationforms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrationform registrationform = db.registrationforms.Find(id);
            if (registrationform == null)
            {
                return HttpNotFound();
            }
            return View(registrationform);
        }

        // GET: registrationforms/Create
        public ActionResult Create()
        {
            ViewBag.regid = new SelectList(db.signins, "Id", "email");
            return View();
        }

        // POST: registrationforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "regid,fname,lname,dob,gender,phonenum,address,email,password")] registrationform registrationform)
        {
            if (ModelState.IsValid)
            {
                db.registrationforms.Add(registrationform);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.regid = new SelectList(db.signins, "Id", "email", registrationform.regid);
            return View(registrationform);
        }

        // GET: registrationforms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrationform registrationform = db.registrationforms.Find(id);
            if (registrationform == null)
            {
                return HttpNotFound();
            }
            ViewBag.regid = new SelectList(db.signins, "Id", "email", registrationform.regid);
            return View(registrationform);
        }

        // POST: registrationforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "regid,fname,lname,dob,gender,phonenum,address,email,password")] registrationform registrationform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.regid = new SelectList(db.signins, "Id", "email", registrationform.regid);
            return View(registrationform);
        }

        // GET: registrationforms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrationform registrationform = db.registrationforms.Find(id);
            if (registrationform == null)
            {
                return HttpNotFound();
            }
            return View(registrationform);
        }

        // POST: registrationforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registrationform registrationform = db.registrationforms.Find(id);
            db.registrationforms.Remove(registrationform);
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

        public ActionResult adminprofile()
        {
            var registrationforms = db.registrationforms.Include(r => r.signin);
            return View(registrationforms.ToList());
        }
    }
}
