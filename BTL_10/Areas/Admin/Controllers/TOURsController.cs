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
    public class TOURsController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/TOURs
        public ActionResult Index()
        {
            var tOURs = db.TOURs.Include(t => t.HUONGDANVIEN);
            return View(tOURs.ToList());
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
            ViewBag.MAHDV = new SelectList(db.HUONGDANVIENs, "MAHDV", "TENHDV");
            return View();
        }

        // POST: Admin/TOURs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATOUR,TENTOUR,NGAYBD,NGAYKT,GIA,MAHDV,CHITIETTOUR,ANH")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.TOURs.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHDV = new SelectList(db.HUONGDANVIENs, "MAHDV", "TENHDV", tOUR.MAHDV);
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
            return View(tOUR);
        }

        // POST: Admin/TOURs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATOUR,TENTOUR,NGAYBD,NGAYKT,GIA,MAHDV,CHITIETTOUR,ANH")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHDV = new SelectList(db.HUONGDANVIENs, "MAHDV", "TENHDV", tOUR.MAHDV);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TOUR tOUR = db.TOURs.Find(id);
            db.TOURs.Remove(tOUR);
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
