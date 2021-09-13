using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Phones = new PhonesDAO().CountPhones();
            ViewBag.user = new UserDAO().CountUser();
            ViewBag.comment = new CommentDAO().CountComment();
            ViewBag.order = new OrderDAO().CountOrder();
            return View();
        }        
    }
}