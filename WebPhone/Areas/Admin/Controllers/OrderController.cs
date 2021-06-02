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
    public class OrderController : BasicController
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
            var order_detail = new OrderDAO().ViewDetail(id);
            return View(order_detail);
        }
        [HttpPost]
        public ActionResult Detail(Order_detail order_detail)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDAO();
                var result = dao.ViewOrder(order_detail);
                if (result)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật đơn hàng thành công");
                }
            }
            return View("Index");
        }
    }
}