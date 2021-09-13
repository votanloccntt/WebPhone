using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Areas.Admin.Controllers
{
    public class PhonesController : BaseController
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new PhonesDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        // GET: Admin/Phones
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var phones = new PhonesDAO().ViewDetail(id);
            return View(phones);
        }
        [HttpPost]
        public ActionResult Create(Phones phones)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhonesDAO();
                long id = dao.Insert(phones);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Phones");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Phones phones)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhonesDAO();
                var result = dao.Update(phones);
                if (result)
                {
                    return RedirectToAction("Index", "Phones");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new PhonesDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}