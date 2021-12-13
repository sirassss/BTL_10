using BTL_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace BTL_10.Controllers
{
    public class TOURsController : Controller
    {
        TourStore db = new TourStore();
        // GET: TOURs
        public ActionResult Index(int? page,string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTenAZ = "ten_asc";
            ViewBag.SapTheoTenZA = "ten_desc";
            ViewBag.GiaTangDan = "gia_asc";
            ViewBag.GiaGiamDan = "gia_desc";
            var listtour = db.TOURs.ToList();
            switch (sortOrder)
            {
                case "ten_asc":
                    listtour = listtour.OrderByDescending(s => s.TENTOUR).ToList();
                    break;
                case "ten_desc":
                    listtour = listtour.OrderBy(s => s.TENTOUR).ToList();
                    break;
                case "gia_asc":
                    listtour = listtour.OrderBy(s => s.GIA).ToList();
                    break;
                case "gia_desc":
                    listtour = listtour.OrderByDescending(s => s.GIA).ToList();
                    break;
                default:
                    listtour = listtour.OrderBy(s => s.TENTOUR).ToList();
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(listtour.ToPagedList(pageNumber, pageSize));
        }

        // GET: TOURs/Details/5
        
        public ActionResult Details(string id)
        {
            TOUR tour = db.TOURs.Where(x=>x.MATOUR==id).FirstOrDefault();
            ViewBag.phuongtien = db.PHUONGTIENs.Where(x => x.MATOUR == tour.MATOUR).FirstOrDefault();
            ViewBag.khachsan = db.KHACHSANs.Where(x => x.MATOUR == tour.MATOUR).FirstOrDefault();
            ViewBag.diadiem = db.DIEMTHAMQUANs.Take(3).ToList();
            return View(tour);
        }

        // GET: TOURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TOURs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TOURs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TOURs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TOURs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TOURs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
