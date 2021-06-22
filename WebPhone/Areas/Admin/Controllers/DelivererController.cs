using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Areas.Admin.Controllers
{
    public class DelivererController : BaseController
    {
        // GET: Admin/Deliverer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DelivererDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var deliverer = new DelivererDAO().ViewDetail(id);
            return View(deliverer);
        }
        [HttpPost]
        public ActionResult Create(Deliverer deliverer)
        {
            if (ModelState.IsValid)
            {
                var dao = new DelivererDAO();
                long id = dao.Insert(deliverer);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Deliverer");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Nhân viên thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Deliverer deliverer)
        {
            if (ModelState.IsValid)
            {
                var dao = new DelivererDAO();
                var result = dao.Update(deliverer);
                if (result)
                {
                    return RedirectToAction("Index", "Deliverer");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật nhân viên thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new DelivererDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}