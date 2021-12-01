using BTL_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_10.Controllers
{
    public class TOURsController : Controller
    {
        TourStore db = new TourStore();
        // GET: TOURs
        public ActionResult Index()
        {
            var listtour = db.TOURs.ToList();
            return View(listtour);
        }

        // GET: TOURs/Details/5
        public ActionResult Details(int id)
        {
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
