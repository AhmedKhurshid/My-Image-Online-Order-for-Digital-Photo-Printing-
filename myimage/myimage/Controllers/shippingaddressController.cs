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
    public class shippingaddressController : Controller
    {
        private myimagedatabaseEntities db = new myimagedatabaseEntities();

        // GET: shippingaddress
        public ActionResult Index()
        {
            return View(db.bilingaddresses.ToList());
        }

        // GET: shippingaddress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bilingaddress bilingaddress = db.bilingaddresses.Find(id);
            if (bilingaddress == null)
            {
                return HttpNotFound();
            }
            return View(bilingaddress);
        }

        // GET: shippingaddress/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: shippingaddress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bilid,Fname,Lname,Address,ContactNumb,State,PostalCode")] bilingaddress bilingaddress)
        {
            if (ModelState.IsValid)
            {
                db.bilingaddresses.Add(bilingaddress);
                db.SaveChanges();
                return RedirectToAction("Create","paymentdetails");
            }

            return View(bilingaddress);
        }

        // GET: shippingaddress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bilingaddress bilingaddress = db.bilingaddresses.Find(id);
            if (bilingaddress == null)
            {
                return HttpNotFound();
            }
            return View(bilingaddress);
        }

        // POST: shippingaddress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bilid,Fname,Lname,Address,ContactNumb,State,PostalCode")] bilingaddress bilingaddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilingaddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilingaddress);
        }

        // GET: shippingaddress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bilingaddress bilingaddress = db.bilingaddresses.Find(id);
            if (bilingaddress == null)
            {
                return HttpNotFound();
            }
            return View(bilingaddress);
        }

        // POST: shippingaddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bilingaddress bilingaddress = db.bilingaddresses.Find(id);
            db.bilingaddresses.Remove(bilingaddress);
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
