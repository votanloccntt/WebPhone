using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new OrderDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var order_detail = new OrderDetailDAO().ViewDetail(id);
            return View(order_detail);
        }
        [HttpGet]
        public ActionResult Processing(int id)
        {
            var processing = new OrderDAO().ViewDetail(id);
            return View(processing);
        }
        [HttpPost]
        public ActionResult Processing(Order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDAO();
                var result = dao.Update(order);
                if (result)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Xử lí hóa đơn thành công");
                }
            }
            return View("Index");
        }
    }
}