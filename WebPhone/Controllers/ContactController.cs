using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var dao = new CommentDAO();
                long id = dao.Insert(comment);
                if (id > 0)
                {
                    ViewBag.Success = "Liên hệ thành công";
                }
            }
            return View("Index");
        }
    }
}