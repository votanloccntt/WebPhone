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
        public ActionResult CategoryDetail(int categoryID)
        {
            var category = new CategoryDAO().ViewDetail(categoryID);
            return View(category);
        }
    }
}