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
        public JsonResult Login(string username, string password)
        {
            ADMIN ad = db.ADMINs.SingleOrDefault(x => x.TENDN == username && x.MK == password);
            if (ad != null && ad.LOAITK.Trim() == "admin")
            {
                Session[Account.ADMIN_SESSION] = ad;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else if (ad != null && ad.LOAITK.Trim() == "nhanvien")
            {
                Session[Account.NV_SESSION] = ad;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else if (ad == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            return Json(false, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password, string hovaten)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var idnv = new string(stringChars);
            ADMIN ad = new ADMIN() { ID = idnv, TENDN = username, MK = password, HOTEN = hovaten, LOAITK = "nhanvien", TRANGTHAI = "on" };
            db.ADMINs.Add(ad);
            db.SaveChanges();
            Session[Account.NV_SESSION] = ad;
            return RedirectToAction("Index", "Home");
        }
    }
}