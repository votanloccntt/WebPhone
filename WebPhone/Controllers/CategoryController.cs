using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhone.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }
        public ActionResult CategoryDetail(int categoryID, int page = 1, int pageSize = 1)
        {
            var category = new CategoryDAO().ViewDetail(categoryID);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new PhonesDAO().ListByCategoryId(categoryID, ref totalRecord,page,pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}