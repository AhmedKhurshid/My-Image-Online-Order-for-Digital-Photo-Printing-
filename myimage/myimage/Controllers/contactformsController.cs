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
    public class contactformsController : Controller
    {
        private myimagedatabaseEntities db = new myimagedatabaseEntities();

        // GET: contactforms
        public ActionResult Index()
        {
            return View(db.contactforms.ToList());
        }

        // GET: contactforms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactform contactform = db.contactforms.Find(id);
            if (contactform == null)
            {
                return HttpNotFound();
            }
            return View(contactform);
        }

        // GET: contactforms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contactforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ctcid,First_Name,Last_Name,Email,Subject,Message")] contactform contactform)
        {
            if (ModelState.IsValid)
            {
                db.contactforms.Add(contactform);
                db.SaveChanges();
                ViewBag.send = "SEND SUCCESSFULLY";
                return RedirectToAction("Create");
            }

            return View(contactform);
        }

        // GET: contactforms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactform contactform = db.contactforms.Find(id);
            if (contactform == null)
            {
                return HttpNotFound();
            }
            return View(contactform);
        }

        // POST: contactforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ctcid,First_Name,Last_Name,Email,Subject,Message")] contactform contactform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactform);
        }

        // GET: contactforms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactform contactform = db.contactforms.Find(id);
            if (contactform == null)
            {
                return HttpNotFound();
            }
            return View(contactform);
        }

        // POST: contactforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactform contactform = db.contactforms.Find(id);
            db.contactforms.Remove(contactform);
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
