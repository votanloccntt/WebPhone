using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Areas.Admin.Controllers
{
    public class CategoryController : BasicController
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        // GET: Admin/Category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var category = new CategoryDAO().ViewDetail(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                long id = dao.Insert(category);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                var result = dao.Update(category);
                if (result)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh mục thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new CategoryDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}