using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btDotNet.Models;

namespace btDotNet.Controllers
{
    public class NewsItemDbShowController : Controller
    {
        private BtDotNetDb _db = new BtDotNetDb();
        
        //
        // GET: /NewsItemDbShow/

        public ActionResult Index()
        {
            ViewBag.Message = "The NewsItemDb index has loaded.";
            return View(_db.NewsItems.ToList());
        }

        //
        // GET: /NewsItemDbShow/Details/5

        public ActionResult Details(int id = 0)
        {
            NewsItem newsItem = _db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return new HttpNotFoundResult("This doesn't exist");
            }
            return View(newsItem);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Refresh()
        {
            _db.RefreshNewsItems();
            return RedirectToAction("Index");
        }
    }
}