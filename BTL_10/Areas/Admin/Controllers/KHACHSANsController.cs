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
    public class KHACHSANsController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/KHACHSANs
        public ActionResult Index()
        {
            var kHACHSANs = db.KHACHSANs.Include(k => k.TOUR);
            return View(kHACHSANs.ToList());
        }

        // GET: Admin/KHACHSANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHSAN kHACHSAN = db.KHACHSANs.Find(id);
            if (kHACHSAN == null)
            {
                return HttpNotFound();
            }
            return View(kHACHSAN);
        }

        // GET: Admin/KHACHSANs/Create
        public ActionResult Create()
        {
            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR");
            return View();
        }

        // POST: Admin/KHACHSANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKS,MATOUR,TENKS,DIACHI")] KHACHSAN kHACHSAN)
        {
            if (ModelState.IsValid)
            {
                db.KHACHSANs.Add(kHACHSAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR", kHACHSAN.MATOUR);
            return View(kHACHSAN);
        }

        // GET: Admin/KHACHSANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHSAN kHACHSAN = db.KHACHSANs.Find(id);
            if (kHACHSAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR", kHACHSAN.MATOUR);
            return View(kHACHSAN);
        }

        // POST: Admin/KHACHSANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKS,MATOUR,TENKS,DIACHI")] KHACHSAN kHACHSAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHSAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATOUR = new SelectList(db.TOURs, "MATOUR", "TENTOUR", kHACHSAN.MATOUR);
            return View(kHACHSAN);
        }

        // GET: Admin/KHACHSANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHSAN kHACHSAN = db.KHACHSANs.Find(id);
            if (kHACHSAN == null)
            {
                return HttpNotFound();
            }
            return View(kHACHSAN);
        }

        // POST: Admin/KHACHSANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACHSAN kHACHSAN = db.KHACHSANs.Find(id);
            db.KHACHSANs.Remove(kHACHSAN);
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
