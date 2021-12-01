using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_10.Models;

namespace BTL_10.Areas.Admin.Controllers
{
    public class PHUONGTIENsController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/PHUONGTIENs
        public ActionResult Index()
        {
            var pHUONGTIENs = db.PHUONGTIENs.Include(p => p.TOUR);
            return View(pHUONGTIENs.ToList());
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
            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR");
            return View();
        }

        // POST: Admin/PHUONGTIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPHUONGTIEN,MATOUR,TENPHUONGTIEN")] PHUONGTIEN pHUONGTIEN)
        {
            if (ModelState.IsValid)
            {
                db.PHUONGTIENs.Add(pHUONGTIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR", pHUONGTIEN.MATOUR);
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
            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR", pHUONGTIEN.MATOUR);
            return View(pHUONGTIEN);
        }

        // POST: Admin/PHUONGTIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPHUONGTIEN,MATOUR,TENPHUONGTIEN")] PHUONGTIEN pHUONGTIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHUONGTIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR", pHUONGTIEN.MATOUR);
            return View(pHUONGTIEN);
        }

        // GET: Admin/PHUONGTIENs/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Admin/PHUONGTIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHUONGTIEN pHUONGTIEN = db.PHUONGTIENs.Find(id);
            db.PHUONGTIENs.Remove(pHUONGTIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
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
