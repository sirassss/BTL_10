using BTL_10.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_10.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home

        public ActionResult Index()
        {
            if (Session[Account.ADMIN_SESSION] == null)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}