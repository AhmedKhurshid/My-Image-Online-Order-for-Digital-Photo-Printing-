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
    public class paymentdetailsController : Controller
    {
        private myimagedatabaseEntities db = new myimagedatabaseEntities();

        // GET: paymentdetails
        public ActionResult Index()
        {
            return View(db.paymentdetails.ToList());
        }

        // GET: paymentdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paymentdetail paymentdetail = db.paymentdetails.Find(id);
            if (paymentdetail == null)
            {
                return HttpNotFound();
            }
            return View(paymentdetail);
        }

        // GET: paymentdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: paymentdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pyid,Cardnumber,expdate,cvcode,cardowner")] paymentdetail paymentdetail)
        {
            if (ModelState.IsValid)
            {
                db.paymentdetails.Add(paymentdetail);
                db.SaveChanges();
                return RedirectToAction("orderconfirm", "ShoppingCart");
            }

            return View(paymentdetail);
        }

        // GET: paymentdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paymentdetail paymentdetail = db.paymentdetails.Find(id);
            if (paymentdetail == null)
            {
                return HttpNotFound();
            }
            return View(paymentdetail);
        }

        // POST: paymentdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pyid,Cardnumber,expdate,cvcode,cardowner")] paymentdetail paymentdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentdetail);
        }

        // GET: paymentdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paymentdetail paymentdetail = db.paymentdetails.Find(id);
            if (paymentdetail == null)
            {
                return HttpNotFound();
            }
            return View(paymentdetail);
        }

        // POST: paymentdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paymentdetail paymentdetail = db.paymentdetails.Find(id);
            db.paymentdetails.Remove(paymentdetail);
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
