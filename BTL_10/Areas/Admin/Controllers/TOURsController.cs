using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_10.Models;
using BTL_10.Session;

namespace BTL_10.Areas.Admin.Controllers
{
    public class TOURsController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/TOURs
        public ActionResult Index()
        {
            if (Session[Account.ADMIN_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            IQueryable<TOUR> tOURs = (from TOUR in db.TOURs
                                      select TOUR).Include("HUONGDANVIEN").Include("KHACHSAN").Include("PHUONGTIEN");
            //db.TOURs.Include("HUONGDANVIEN").Include("KHACHSAN").Include("PHUONGTIEN").Include("DEN").ToList();
            return View(tOURs);
        }

        // GET: Admin/TOURs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // GET: Admin/TOURs/Create
        public ActionResult Create()
        {
            if (Session[Account.ADMIN_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.MAHDV = new SelectList(db.HUONGDANVIENs, "MAHDV", "TENHDV");
            ViewBag.MAKS = new SelectList(db.KHACHSANs, "MAKS", "TENKS");
            ViewBag.MAPHUONGTIEN = new SelectList(db.PHUONGTIENs, "MAPHUONGTIEN", "TENPHUONGTIEN");
            ViewBag.DIEMTHAMQUAN = db.DIEMTHAMQUANs.Take(4).ToList();
            return View();
        }

        // POST: Admin/TOURs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MATOUR,TENTOUR,NGAYBD,NGAYKT,GIA,MAHDV,CHITIETTOUR,ANH,MAKS,MAPHUONGTIEN,DIEMTHAMQUAN")] TOUR tOUR, List<string> listid)
        {
            if (ModelState.IsValid)
            {
                foreach (string item in listid)
                {
                    tOUR.DENs.Add(new DEN() { MADD = item, MATOUR = tOUR.MATOUR });
                }
                tOUR.ANH = "";
                var f = Request.Files["Imagefile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UpLoadPath = Server.MapPath("~/Areas/Admin/Data/Tour/" + FileName);
                    f.SaveAs(UpLoadPath);
                    tOUR.ANH = FileName;
                }
                db.TOURs.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHDV = new SelectList(db.HUONGDANVIENs, "MAHDV", "TENHDV", tOUR.MAHDV);
            ViewBag.MAKS = new SelectList(db.KHACHSANs, "MAKS", "TENKS", tOUR.MAKS);
            ViewBag.MAPHUONGTIEN = new SelectList(db.PHUONGTIENs, "MAPHUONGTIEN", "TENPHUONGTIEN", tOUR.MAPHUONGTIEN);
            ViewBag.DIEMTHAMQUAN = db.DIEMTHAMQUANs.Take(4).ToList();
            return View(tOUR);
        }

        // GET: Admin/TOURs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHDV = new SelectList(db.HUONGDANVIENs, "MAHDV", "TENHDV", tOUR.MAHDV);
            ViewBag.MAKS = new SelectList(db.KHACHSANs, "MAKS", "TENKS", tOUR.MAKS);
            ViewBag.MAPHUONGTIEN = new SelectList(db.PHUONGTIENs, "MAPHUONGTIEN", "TENPHUONGTIEN", tOUR.MAPHUONGTIEN);
            return View(tOUR);
        }

        // POST: Admin/TOURs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MATOUR,TENTOUR,NGAYBD,NGAYKT,GIA,MAHDV,CHITIETTOUR,ANH,MAKS,MAPHUONGTIEN,DIEMTHAMQUAN")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["Imagefile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UpLoadPath = Server.MapPath("~/Areas/Admin/Data/Tour/" + FileName);
                    f.SaveAs(UpLoadPath);
                    tOUR.ANH = FileName;
                }
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHDV = new SelectList(db.HUONGDANVIENs, "MAHDV", "TENHDV", tOUR.MAHDV);
            ViewBag.MAKS = new SelectList(db.KHACHSANs, "MAKS", "TENKS", tOUR.MAKS);
            ViewBag.MAPHUONGTIEN = new SelectList(db.PHUONGTIENs, "MAPHUONGTIEN", "TENPHUONGTIEN", tOUR.MAPHUONGTIEN);
            return View(tOUR);
        }

        // GET: Admin/TOURs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // POST: Admin/TOURs/Delete/5
        [HttpPost]
        public JsonResult DeleteConfirmed(string id)
        {
            TOUR tOUR = db.TOURs.Find(id);
            List<DEN> dens = db.DENs.Where(s => s.MATOUR == id).ToList();
            for (var i = 0; i < dens.Count; i++)
            {
                DEN x = db.DENs.Where(s => s.MATOUR == id).FirstOrDefault();
                if (x != null)
                {
                    db.DENs.Remove(x);
                    db.SaveChanges();
                }
            }
            db.TOURs.Remove(tOUR);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult DeleteConfirme(string id)
        //{

        //    return View();
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
