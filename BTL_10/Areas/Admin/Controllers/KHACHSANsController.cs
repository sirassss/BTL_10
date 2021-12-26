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
    public class KHACHSANsController : BaseController
    {
        private TourStore db = new TourStore();

        // GET: Admin/KHACHSANs
        public ActionResult Index()
        {
            return View(db.KHACHSANs.ToList());
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
            return View();
        }

        // POST: Admin/KHACHSANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKS,TENKS,DIACHI")] KHACHSAN kHACHSAN)
        {
            if (ModelState.IsValid)
            {
                db.KHACHSANs.Add(kHACHSAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(kHACHSAN);
        }

        // POST: Admin/KHACHSANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKS,TENKS,DIACHI")] KHACHSAN kHACHSAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHSAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHACHSAN);
        }


        // POST: Admin/KHACHSANs/Delete/5
        [HttpPost]
        public JsonResult DeleteConfirmed(string id)
        {
            KHACHSAN kHACHSAN = db.KHACHSANs.Find(id);
            //Xóa bảng TOUR
            List<TOUR> lst = db.TOURs.Where(t => t.MAKS == id).ToList();
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
            db.KHACHSANs.Remove(kHACHSAN);
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
