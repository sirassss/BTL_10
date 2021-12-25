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
    public class BLOGsController : BaseController
    {
        private TourStore db = new TourStore();

        // GET: Admin/BLOGs
        public ActionResult Index()
        {
            var bLOGs = db.BLOGs.Include(b => b.ADMIN).Include(b => b.DANHMUCBLOG);
            return View(bLOGs.ToList());
        }

        // GET: Admin/BLOGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // GET: Admin/BLOGs/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ADMINs, "ID", "TENDN");
            ViewBag.MADANHMUCBLOG = new SelectList(db.DANHMUCBLOGs, "MADANHMUCBLOG", "TENDANHMUCBLOG");
            return View();
        }

        // POST: Admin/BLOGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MABAIVIET,ID,MADANHMUCBLOG,TIEUDE,ANH,TOMTAT,NOIDUNG,NGAYKHOITAO")] BLOG bLOG)
        {
            if (ModelState.IsValid)
            {
                bLOG.ANH = "";
                var f = Request.Files["Imagefile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UpLoadPath = Server.MapPath("~/Areas/Admin/Data/Blog/" + FileName);
                    f.SaveAs(UpLoadPath);
                    bLOG.ANH = FileName;
                }
                db.BLOGs.Add(bLOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ADMINs, "ID", "TENDN", bLOG.ID);
            ViewBag.MADANHMUCBLOG = new SelectList(db.DANHMUCBLOGs, "MADANHMUCBLOG", "TENDANHMUCBLOG", bLOG.MADANHMUCBLOG);
            return View(bLOG);
        }

        // GET: Admin/BLOGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ADMINs, "ID", "TENDN", bLOG.ID);
            ViewBag.MADANHMUCBLOG = new SelectList(db.DANHMUCBLOGs, "MADANHMUCBLOG", "TENDANHMUCBLOG", bLOG.MADANHMUCBLOG);
            return View(bLOG);
        }

        // POST: Admin/BLOGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MABAIVIET,ID,MADANHMUCBLOG,TIEUDE,ANH,TOMTAT,NOIDUNG,NGAYKHOITAO")] BLOG bLOG)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["Imagefile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UpLoadPath = Server.MapPath("~/Areas/Admin/Data/Blog/" + FileName);
                    f.SaveAs(UpLoadPath);
                    bLOG.ANH = FileName;
                }
                db.Entry(bLOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ADMINs, "ID", "TENDN", bLOG.ID);
            ViewBag.MADANHMUCBLOG = new SelectList(db.DANHMUCBLOGs, "MADANHMUCBLOG", "TENDANHMUCBLOG", bLOG.MADANHMUCBLOG);
            return View(bLOG);
        }

        // GET: Admin/BLOGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: Admin/BLOGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BLOG bLOG = db.BLOGs.Find(id);
            db.BLOGs.Remove(bLOG);
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
