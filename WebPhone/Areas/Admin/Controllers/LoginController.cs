using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPhone.Areas.Admin.Models;

namespace WebPhone.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            
            if(Membership.ValidateUser(model.Username,model.Password) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Username,model.Rememberme);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("",string.Format("Tài khoản hoặc mật khẩu không đúng."));
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}