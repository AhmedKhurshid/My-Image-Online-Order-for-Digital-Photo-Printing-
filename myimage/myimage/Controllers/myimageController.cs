using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myimage.Models;
using System.Net.Mail;
using System.Net;
using System.IO;



namespace myimage.Controllers
{
    
    public class myimageController : Controller
    {
        // GET: myimage
        myimagedatabaseEntities db = new myimagedatabaseEntities();

      
        public ActionResult Index()
        {
            return View();
        }
       
        
        public ActionResult rigistrationform()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult rigistrationform(registrationform user)   
        {
            //Console.Write("Registration Complete");
            db.registrationforms.Add(user);
            db.SaveChanges();
           
            

            return RedirectToAction("signin");
        }

        [HttpGet]
        public ActionResult signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signin(registrationform lgn)
        {

            registrationform sgn = db.registrationforms.Where(model => model.email == lgn.email && model.password == lgn.password).FirstOrDefault();
            if(sgn !=null)
            {

                    Session["email"] = lgn.email;
                    Session["name"] = lgn.fname;    
                    Session["UserId"] = lgn.regid;
                    return RedirectToAction("home", "myimage");

                    
                }
                else 
                {

                ViewBag.str = "Registration Failed";
                    return RedirectToAction("signin", "myimage");
                }
        }


        public ActionResult logout()
        {
            Session.Abandon();
          
            
            return RedirectToAction("signin","myimage");

            
        }
        public ActionResult home()
        {
            

            return View();
        }

       

        public ActionResult shopmetallicprint()
        {


            return View();
        }
        //=========================

        public ActionResult aboutus()
        {


            return View();
        }


        public ActionResult Contactus()
        {


            return View();
        }
    }
}