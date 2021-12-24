using BTL_10.Models;
using BTL_10.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_10.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        TourStore db = new TourStore();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ADMIN ad = db.ADMINs.SingleOrDefault(x => x.TENDN == username && x.MK == password);
            if (ad != null)
            {
                Session[Account.ADMIN_SESSION] = ad;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View("Index");
        }
    }
}