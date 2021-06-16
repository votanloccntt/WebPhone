using System.Web.Mvc;

namespace WebPhone.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { area = "Admin", controller = "Register", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { area = "Admin", controller = "Login", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Areas.Admin.Controllers" }
            );
        }
    }
}