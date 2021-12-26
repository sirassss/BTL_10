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
    public class HUONGDANVIENsController : BaseController
    {
        private TourStore db = new TourStore();

        // GET: Admin/HUONGDANVIENs
        public ActionResult Index()
        {
            return View(db.HUONGDANVIENs.ToList());
        }


        // GET: Admin/HUONGDANVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HUONGDANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHDV,TENHDV,PHAI,DIACHI,SDT")] HUONGDANVIEN hUONGDANVIEN, bool gioitinh)
        {
            if (ModelState.IsValid)
            {
                hUONGDANVIEN.PHAI = gioitinh;
                db.HUONGDANVIENs.Add(hUONGDANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hUONGDANVIEN);
        }

        // GET: Admin/HUONGDANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HUONGDANVIEN hUONGDANVIEN = db.HUONGDANVIENs.Find(id);
            if (hUONGDANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(hUONGDANVIEN);
        }

        // POST: Admin/HUONGDANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHDV,TENHDV,PHAI,DIACHI,SDT")] HUONGDANVIEN hUONGDANVIEN, bool gioitinh)
        {
            if (ModelState.IsValid)
            {
                hUONGDANVIEN.PHAI = gioitinh;
                db.Entry(hUONGDANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hUONGDANVIEN);
        }


        // POST: Admin/HUONGDANVIENs/Delete/5
        [HttpPost]
        public JsonResult DeleteConfirmed(string id)
        {
            HUONGDANVIEN hUONGDANVIEN = db.HUONGDANVIENs.Find(id);
            //Xóa bảng TOUR
            List<TOUR> lst = db.TOURs.Where(t => t.MAHDV == id).ToList();
            for (var i = 0; i < lst.Count; i++)
            {
                TOUR t = lst[0];
                //Xóa bảng DEN
                List<DEN> lstdendl = db.DENs.Where(d => d.MATOUR == t.MATOUR).ToList();
                for (var j = 0; j < lstdendl.Count; j++)
                {
                    if (lstdendl.Count != 0)
                    {
                        db.DENs.Remove(lstdendl[j]);
                        db.SaveChanges();
                    }

                }
                //Xóa bảng DANGKY
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
            db.HUONGDANVIENs.Remove(hUONGDANVIEN);
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
