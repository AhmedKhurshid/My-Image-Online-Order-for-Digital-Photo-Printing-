using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myimage.Models;


namespace myimage.Controllers
{
    public class adminController : Controller
    {
        myimagedatabaseEntities db = new myimagedatabaseEntities();
        // GET: admin
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("signin", "myimage");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult adminsignin()
        {


            return View();
        }

        [HttpPost]
        public ActionResult adminsignin(registrationform lgn)
        {
            registrationform sgn = db.registrationforms.Where(model => model.email == lgn.email && model.password == lgn.password).FirstOrDefault();
            if (sgn != null)
            {

                if (sgn.regid == 1)
                {
                    Session["email"] = lgn.email;
                    Session["UserId"] = lgn.regid;
                    Session["fname"] = lgn.fname;
                    return RedirectToAction("Index", "admin");
                }
                else
                {
                    ViewBag.str = "Registration Failed";
                    return RedirectToAction("adminsignin", "admin");
                }

            }

            return View();
            
        }

        //============================

        public ActionResult logout()
        {
            Session.Abandon();

            return RedirectToAction("signin","myimage");
        }

        public ActionResult usercart()
        {
            return View(); 
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].sz.sizeid == id)
                    return i;
            return -1;
        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("usercart");
        }

    }
}