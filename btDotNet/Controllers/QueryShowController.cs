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
    public class QueryShowController : Controller
    {
        private BtDotNetDb db = new BtDotNetDb();

        //
        // GET: /QueryShow/

        public ActionResult Index()
        {
            return View(db.Queries.ToList());
        }

        //
        // GET: /QueryShow/Details/5

        public ActionResult Details(int id = 0)
        {
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: /QueryShow/Create

        [HttpPost]
        public ActionResult Create(Query query)
        {
            if (ModelState.IsValid)
            {
                db.Queries.Add(query);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewName:"Error");
        }

        //
        // GET: /QueryShow/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        //
        // POST: /QueryShow/Edit/5

        [HttpPost]
        public ActionResult Edit(Query query)
        {
            if (ModelState.IsValid)
            {
                db.Entry(query).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(query);
        }

        //
        // GET: /QueryShow/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        //
        // POST: /QueryShow/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Query query = db.Queries.Find(id);
            db.Queries.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public PartialViewResult CreateQuery()
        {
            return PartialView("_EditQueryPartial", new Query());
        }
    }
}