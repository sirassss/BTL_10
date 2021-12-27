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
            if (ad.TRANGTHAI.Trim() == "off")
            {
                var data = new { status = "lock" };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if (ad != null && ad.LOAITK.Trim() == "admin")
            {
                Session[Account.ADMIN_SESSION] = ad;
                var data = new { status = "ok"};
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if (ad != null && ad.LOAITK.Trim() == "nhanvien")
            {
                Session[Account.NV_SESSION] = ad;
                var data = new { status = "ok"};
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if (ad == null)
            {
                var data = new { status = "not" };
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            
            return Json(new { status = "nots"}, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(string username, string password, string hovaten)
        {
            ADMIN check = db.ADMINs.SingleOrDefault(c => c.TENDN == username);
            if (check != null)
            {
                return Json(new { status = "not" }, JsonRequestBehavior.AllowGet);
            }
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
            return Json(new { status = "ok" }, JsonRequestBehavior.AllowGet);
        }
    }
}