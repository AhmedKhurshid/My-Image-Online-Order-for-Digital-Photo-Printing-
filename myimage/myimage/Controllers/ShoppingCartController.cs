using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myimage.Models;
using System.IO;

namespace myimage.Controllers
{
    public class ShoppingCartController : Controller
    {
        private  myimagedatabaseEntities de = new myimagedatabaseEntities();
        // GET: ShoppingCart
        public ActionResult Index()
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
            return View("Cart");
        }
        //public ActionResult Ordernow(int id)
        //{
        //    var q = de.images.ToList();


        //    if (Session["cart"] == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        cart.Add ( new Item(de.sizeprizes.Find(id), 1));
        //        Session["cart"] = cart;
        //    }
        //    else
        //    {
        //        List<Item> cart = (List<Item>)Session["cart"];
        //        int index = isExisting(id);
        //        if (index == -1)
        //            cart.Add(new Item(de.sizeprizes.Find(id), 1));
        //        else
        //            cart[index].Quantity++;
        //        Session["cart"] = cart;
        //    }

        //    return View("Cart");
        //}

        public ActionResult Cart(int id)
        {
            var q = de.images.ToList();


            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(de.sizeprizes.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(de.sizeprizes.Find(id), 1));
                else
                    cart[index].Quantity++;
                Session["cart"] = cart;
            }

            return View(q);
        }

        public ActionResult adimg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adimg(HttpPostedFileBase myfile,image p)
        {
            var fileName = "";

            try { 
           fileName = Path.GetFileName(myfile.FileName);
            var filecontent = myfile.ContentType.ToString();
            if (myfile.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/docs"), fileName);
                myfile.SaveAs(path);
                ViewBag.a = "File saved!"; 
            }
            }
            catch (Exception ex)
            {
                ViewBag.str = ex.Message.ToString();
            }
            p.image1 = "~/docs/" + fileName;
            de.images.Add(p);
            de.SaveChanges();
            return View("Cart");
        }

        public ActionResult addtocart()
        {
            var q = de.images.ToList();

            return View(q);
        }


        //public ActionResult addbilling()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult addbilling(bilingaddress bil)
        //{
        //    de.bilingaddresses.Add(bil);
        //    de.SaveChanges();
        //    return RedirectToAction("paymentdetail");
        //}

        //public ActionResult paymentdetail()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult paymentdetail(paymentdetail paym)
        //{
        //    de.paymentdetails.Add(paym);
        //    de.SaveChanges();

        //    return View("orderconfirm");
        //}

        public ActionResult orderconfirm()
        {


            return View();
        }
    }
}