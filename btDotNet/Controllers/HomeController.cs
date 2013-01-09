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
    public class HomeController : Controller
    {
        private BtDotNetDb _db = new BtDotNetDb();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "The index has loaded.";

            TokenCounter tkCtr = null;
            if (_db.NewsItems.Any())
            {
                tkCtr = new TokenCounter(_db.NewsItems);
            }
            if (tkCtr != null)
            {
                ViewData["tokens"] = tkCtr;
            }
            return View(_db.NewsItems.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}