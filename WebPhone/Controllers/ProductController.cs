using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetail(int productID)
        {
            var product = new PhonesDAO().ViewDetail(productID);
            ViewBag.Product = new PhonesDAO().ViewDetail(product.Phones_id);
            return View(product);
        }
    }
}