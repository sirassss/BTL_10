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
    public class DANHMUCBLOGsController : BaseController
    {
        private TourStore db = new TourStore();

        // GET: Admin/DANHMUCBLOGs
        public ActionResult Index()
        {
            return View(db.DANHMUCBLOGs.ToList());
        }


        // GET: Admin/DANHMUCBLOGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DANHMUCBLOGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADANHMUCBLOG,TENDANHMUCBLOG")] DANHMUCBLOG dANHMUCBLOG)
        {
            if (ModelState.IsValid)
            {
                db.DANHMUCBLOGs.Add(dANHMUCBLOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dANHMUCBLOG);
        }

        // GET: Admin/DANHMUCBLOGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUCBLOG dANHMUCBLOG = db.DANHMUCBLOGs.Find(id);
            if (dANHMUCBLOG == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUCBLOG);
        }

        // POST: Admin/DANHMUCBLOGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADANHMUCBLOG,TENDANHMUCBLOG")] DANHMUCBLOG dANHMUCBLOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANHMUCBLOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dANHMUCBLOG);
        }

        // GET: Admin/DANHMUCBLOGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUCBLOG dANHMUCBLOG = db.DANHMUCBLOGs.Find(id);
            if (dANHMUCBLOG == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUCBLOG);
        }

        // POST: Admin/DANHMUCBLOGs/Delete/5
        [HttpPost]
        public JsonResult DeleteConfirmed(string id)
        {
            DANHMUCBLOG dANHMUCBLOG = db.DANHMUCBLOGs.Find(id);
            //Xóa bảng BLOG
            List<BLOG> blogs = db.BLOGs.Where(s => s.ID == id).ToList();
            for (var i = 0; i < blogs.Count; i++)
            {
                if (blogs.Count != 0)
                {
                    db.BLOGs.Remove(blogs[i]);
                    db.SaveChanges();
                }
            }
            db.DANHMUCBLOGs.Remove(dANHMUCBLOG);
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
