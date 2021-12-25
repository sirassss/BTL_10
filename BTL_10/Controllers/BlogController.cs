using BTL_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BTL_10.Controllers
{
    public class BlogController : DefaultController
    {
        TourStore db = new TourStore();
        // GET: Blog
        public ActionResult Index(int ? page)
        {
            var listBlog = db.BLOGs.ToList();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(listBlog.ToPagedList(pageNumber, pageSize));
        }
        // GET: Blog/Details/5
        public ActionResult Detail(string id)
        {
            BLOG blog = db.BLOGs.Where(s => s.MABAIVIET == id).FirstOrDefault();
            ViewBag.blogLQ = db.BLOGs.Where(s => s.MADANHMUCBLOG == blog.MADANHMUCBLOG).Take(3).ToList();
            return View(blog);
        }
    }
}