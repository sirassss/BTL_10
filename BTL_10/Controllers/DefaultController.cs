using BTL_10.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_10.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                Controller = "Home",
                Action = "Index",
                //Area = "Admin"
            }));
            base.OnActionExecuting(filterContext);
        }
    }
}