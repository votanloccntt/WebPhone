using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var phonesDAO = new PhonesDAO();
            ViewBag.ListNewProducts = phonesDAO.ListNewProduct(3);
            ViewBag.ListPromotionProducts = phonesDAO.ListPromotionProduct(3);
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDAO().ListByGroupId(1);
            return PartialView(model);

        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDAO().GetFooter();
            return PartialView(model);

        }
    }
}