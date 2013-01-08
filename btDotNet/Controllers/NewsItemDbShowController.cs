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
        private BtDotNetDb db = new BtDotNetDb();

        //
        // GET: /NewsItemDbShow/

        public ActionResult Index()
        {
            ViewBag.Message = "The NewsItemDb index has loaded.";
            return View(db.NewsItems.ToList());
        }

        //
        // GET: /NewsItemDbShow/Details/5

        public ActionResult Details(int id = 0)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return HttpNotFound();
            }
            return View(newsItem);
        }

        //
        // GET: /NewsItemDbShow/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NewsItemDbShow/Create

        [HttpPost]
        public ActionResult Create(NewsItem newsItem)
        {
            if (ModelState.IsValid)
            {
                db.NewsItems.Add(newsItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsItem);
        }

        //
        // GET: /NewsItemDbShow/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return HttpNotFound();
            }
            return View(newsItem);
        }

        //
        // POST: /NewsItemDbShow/Edit/5

        [HttpPost]
        public ActionResult Edit(NewsItem newsItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsItem);
        }

        //
        // GET: /NewsItemDbShow/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return HttpNotFound();
            }
            return View(newsItem);
        }

        //
        // POST: /NewsItemDbShow/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            db.NewsItems.Remove(newsItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Refresh()
        {
            var locationManager = new NewsItemLocationManager();
            //locationManager.AddLocation(new NewsItemLocation(@"TestJsonData.json"));
            db.RefreshNewsItems(locationManager);
            return RedirectToAction("Index");
        }
    }
}