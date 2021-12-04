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
    public class DIEMTHAMQUANsController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/DIEMTHAMQUANs
        public ActionResult Index()
        {
            return View(db.DIEMTHAMQUANs.ToList());
        }

        // GET: Admin/DIEMTHAMQUANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEMTHAMQUAN dIEMTHAMQUAN = db.DIEMTHAMQUANs.Find(id);
            if (dIEMTHAMQUAN == null)
            {
                return HttpNotFound();
            }
            return View(dIEMTHAMQUAN);
        }

        // GET: Admin/DIEMTHAMQUANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DIEMTHAMQUANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADD,TENDD,DIACHI,MOTADIEMDEN,ANH")] DIEMTHAMQUAN dIEMTHAMQUAN)
        {
            if (ModelState.IsValid)
            {
                db.DIEMTHAMQUANs.Add(dIEMTHAMQUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dIEMTHAMQUAN);
        }

        // GET: Admin/DIEMTHAMQUANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEMTHAMQUAN dIEMTHAMQUAN = db.DIEMTHAMQUANs.Find(id);
            if (dIEMTHAMQUAN == null)
            {
                return HttpNotFound();
            }
            return View(dIEMTHAMQUAN);
        }

        // POST: Admin/DIEMTHAMQUANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADD,TENDD,DIACHI,MOTADIEMDEN,ANH")] DIEMTHAMQUAN dIEMTHAMQUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIEMTHAMQUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dIEMTHAMQUAN);
        }

        // GET: Admin/DIEMTHAMQUANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEMTHAMQUAN dIEMTHAMQUAN = db.DIEMTHAMQUANs.Find(id);
            if (dIEMTHAMQUAN == null)
            {
                return HttpNotFound();
            }
            return View(dIEMTHAMQUAN);
        }

        // POST: Admin/DIEMTHAMQUANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DIEMTHAMQUAN dIEMTHAMQUAN = db.DIEMTHAMQUANs.Find(id);
            db.DIEMTHAMQUANs.Remove(dIEMTHAMQUAN);
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
