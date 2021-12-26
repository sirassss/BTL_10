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
    public class PHUONGTIENsController : BaseController
    {
        private TourStore db = new TourStore();

        // GET: Admin/PHUONGTIENs
        public ActionResult Index()
        {
            return View(db.PHUONGTIENs.ToList());
        }

        // GET: Admin/PHUONGTIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTIEN pHUONGTIEN = db.PHUONGTIENs.Find(id);
            if (pHUONGTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTIEN);
        }

        // GET: Admin/PHUONGTIENs/Create
        public ActionResult Create()
        {
            if (Session[Account.ADMIN_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Admin/PHUONGTIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPHUONGTIEN,TENPHUONGTIEN")] PHUONGTIEN pHUONGTIEN)
        {
            if (ModelState.IsValid)
            {
                db.PHUONGTIENs.Add(pHUONGTIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHUONGTIEN);
        }

        // GET: Admin/PHUONGTIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHUONGTIEN pHUONGTIEN = db.PHUONGTIENs.Find(id);
            if (pHUONGTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHUONGTIEN);
        }

        // POST: Admin/PHUONGTIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPHUONGTIEN,TENPHUONGTIEN")] PHUONGTIEN pHUONGTIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHUONGTIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHUONGTIEN);
        }


        // POST: Admin/PHUONGTIENs/Delete/5
        [HttpPost]
        public JsonResult DeleteConfirmed(string id)
        {
            PHUONGTIEN pHUONGTIEN = db.PHUONGTIENs.Find(id);
            //Xóa bảng tour
            List<TOUR> lst = db.TOURs.Where(t => t.MAPHUONGTIEN == id).ToList();
            for (var i = 0; i < lst.Count; i++)
            {
                TOUR t = lst[0];
                //Xóa bảng đến
                List<DEN> lstdendl = db.DENs.Where(d => d.MATOUR == t.MATOUR).ToList();
                for (var j = 0; j < lstdendl.Count; j++)
                {
                    if (lstdendl.Count != 0)
                    {
                        db.DENs.Remove(lstdendl[j]);
                        db.SaveChanges();
                    }
                }
                //Xóa bảng đăng ký
                List<DANGKY> lstdk = db.DANGKies.Where(d => d.MATOUR == t.MATOUR).ToList();
                for (var j = 0; j < lstdk.Count; j++)
                {
                    if (lstdk.Count != 0)
                    {
                        db.DANGKies.Remove(lstdk[j]);
                        db.SaveChanges();
                    }
                }
                if (lst.Count != 0)
                {
                    db.TOURs.Remove(lst[i]);
                    db.SaveChanges();
                }
            }
            db.PHUONGTIENs.Remove(pHUONGTIEN);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

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
