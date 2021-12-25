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
    public class PHUONGTIENsController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/PHUONGTIENs
        public ActionResult Index()
        {
            if (Session[Account.ADMIN_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }
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
            List<TOUR> lst = db.TOURs.Where(t => t.MAPHUONGTIEN == id).ToList();
            for (var i = 0; i < lst.Count; i++)
            {
                TOUR t = db.TOURs.Where(s => s.MAPHUONGTIEN == id).FirstOrDefault();
                List<DEN> lstdendl = db.DENs.Where(d => d.MATOUR == t.MATOUR).ToList();
                for (var j = 0; j < lstdendl.Count; i++)
                {
                    DEN d = db.DENs.Where(s => s.MATOUR == t.MATOUR).FirstOrDefault();
                    if (d != null)
                    {
                        db.DENs.Remove(d);
                        db.SaveChanges();
                    }
                }
                if (t != null)
                {
                    db.TOURs.Remove(t);
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
