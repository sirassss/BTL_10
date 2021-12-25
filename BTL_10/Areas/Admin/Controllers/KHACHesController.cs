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
    public class KHACHesController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/KHACHes
        public ActionResult Index()
        {
            return View(db.KHACHes.ToList());
        }

        // GET: Admin/KHACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH kHACH = db.KHACHes.Find(id);
            if (kHACH == null)
            {
                return HttpNotFound();
            }
            return View(kHACH);
        }


        // GET: Admin/KHACHes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH kHACH = db.KHACHes.Find(id);
            if (kHACH == null)
            {
                return HttpNotFound();
            }
            return View(kHACH);
        }

        // POST: Admin/KHACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKHACH,TENKHACH,PHAI,DIACHI,CMND,SDT")] KHACH kHACH, bool gioitinh)
        {
            if (ModelState.IsValid)
            {
                kHACH.PHAI = gioitinh;
                db.Entry(kHACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHACH);
        }

        // GET: Admin/KHACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH kHACH = db.KHACHes.Find(id);
            if (kHACH == null)
            {
                return HttpNotFound();
            }
            return View(kHACH);
        }

        // POST: Admin/KHACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACH kHACH = db.KHACHes.Find(id);
            db.KHACHes.Remove(kHACH);
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
