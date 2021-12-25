using BTL_10.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_10.Models;

namespace BTL_10.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home

        public ActionResult Index()
        {
            ADMIN tkht = (ADMIN)Session[Account.ADMIN_SESSION];
            ADMIN tkht2 = (ADMIN)Session[Account.NV_SESSION];
            if (tkht != null)
            {
                return View(tkht);
            }
            else
            {
                return View(tkht2);
            }
        }
        public ActionResult Profile()
        {
            ADMIN tkht = (ADMIN)Session[Account.ADMIN_SESSION];
            ADMIN tkht2 = (ADMIN)Session[Account.NV_SESSION];
            if (tkht != null)
            {
                return View(tkht);
            }
            else
            {
                return View(tkht2);
            }
            
        }
        
        public ActionResult Logout()
        {
            ADMIN tkht = (ADMIN)Session[Account.ADMIN_SESSION];
            ADMIN tkht2 = (ADMIN)Session[Account.NV_SESSION];
            if (tkht != null)
            {
                Session.Remove(Account.ADMIN_SESSION);
            }
            else
            {
                Session.Remove(Account.NV_SESSION);
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Error()
        {
            if (Session[Account.ADMIN_SESSION] != null)
            {
                return RedirectToAction("Index", "ADMINs");
            }
            return View();
        }
    }
}