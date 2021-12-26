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
        public ActionResult Index(int? page,string SearchString, string sortOrder)
        {
            
            var listtour = db.TOURs.ToList();

            if (SearchString!= null)
            {
                listtour = listtour.Where(p => p.TENTOUR.Contains(SearchString)).ToList();
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTenAZ = "ten_asc";
            ViewBag.SapTheoTenZA = "ten_desc";
            ViewBag.GiaTangDan = "gia_asc";
            ViewBag.GiaGiamDan = "gia_desc";

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
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(listtour.ToPagedList(pageNumber, pageSize));
        }

        // GET: TOURs/Details/5

        public ActionResult Details(string id)
        {
            TOUR tour = db.TOURs.Where(x => x.MATOUR == id).FirstOrDefault();
            ViewBag.TourKhac = db.TOURs.Where(x => x.MATOUR != id).Take(3);
            //ViewBag.diadiem = db.DIEMTHAMQUANs.Take(3).ToList();
            Session["tour"] = tour;
            return View(tour);
        }
        public ActionResult DatTour(string id)
        {
            TOUR tour = db.TOURs.Where(x => x.MATOUR == id).FirstOrDefault();
            ViewBag.tour = tour;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatTour(string id, [Bind(Include = "MAKHACH,TENKHACH,PHAI,DIACHI,CMND,SDT")] KHACH kHACH)
        {
            if (ModelState.IsValid)
            {
                TOUR tourdat = (TOUR)Session["tour"];
                KHACH s = new KHACH();
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                s.MAKHACH = new String(stringChars);
                DANGKY dk = new DANGKY() {MAKHACH= s.MAKHACH, MATOUR= tourdat.MATOUR };
                db.DANGKies.Add(dk);
                s.TENKHACH = kHACH.TENKHACH;
                s.PHAI = kHACH.PHAI;
                s.DIACHI = kHACH.DIACHI;
                s.CMND = kHACH.CMND;
                s.SDT = kHACH.SDT;

                db.KHACHes.Add(s);
                db.SaveChanges();
                TOUR tour = db.TOURs.Where(x => x.MATOUR == id).FirstOrDefault();
                ViewBag.tour = tour;
                return RedirectToAction("XacNhan");
            }
            return View();

        }
        public ActionResult XacNhan()
        {
            Session.Remove("tour");
            return View();
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
