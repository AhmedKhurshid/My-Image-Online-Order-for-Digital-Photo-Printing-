using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myimage.Models;

namespace myimage.Controllers
{
    public class ProductController : Controller
    {
        private myimagedatabaseEntities de = new myimagedatabaseEntities();

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.listsizeprize = de.sizeprizes.ToList();
            ViewBag.listimage = de.images.ToList();
            return View();
        }
    }
}