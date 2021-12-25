using BTL_10.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_10.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var admin = Session[Account.ADMIN_SESSION];
            var nhanvien = Session[Account.NV_SESSION];
            if (admin == null && nhanvien == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "Login",
                    Action = "Index",
                    Area = "Admin"
                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}