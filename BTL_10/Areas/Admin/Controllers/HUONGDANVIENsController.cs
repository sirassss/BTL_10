﻿using System;
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
    public class HUONGDANVIENsController : Controller
    {
        private TourStore db = new TourStore();

        // GET: Admin/HUONGDANVIENs
        public ActionResult Index()
        {
            return View(db.HUONGDANVIENs.ToList());
        }

        // GET: Admin/HUONGDANVIENs/Details/5
        public ActionResult Details(string id)
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
        public ActionResult Create([Bind(Include = "MAHDV,TENHDV,PHAI,DIACHI,SDT")] HUONGDANVIEN hUONGDANVIEN)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "MAHDV,TENHDV,PHAI,DIACHI,SDT")] HUONGDANVIEN hUONGDANVIEN)
        {
            if (ModelState.IsValid)
            {
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
            List<TOUR> lst = db.TOURs.Where(t => t.MAHDV == id).ToList();
            for (var i = 0; i < lst.Count; i++)
            {
                TOUR t = db.TOURs.Where(s => s.MAHDV == id).FirstOrDefault();
                List<DEN> lstdendl = db.DENs.Where(d => d.MATOUR == t.MATOUR).ToList();
                for (var j = 0; j < lstdendl.Count; i++)
                {
                    DEN d = db.DENs.Where(s => s.MATOUR == t.MATOUR).FirstOrDefault();
                    if(d != null)
                    {
                        db.DENs.Remove(d);
                        db.SaveChanges();
                    }
                }
                db.TOURs.Remove(t);
                db.SaveChanges();
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
