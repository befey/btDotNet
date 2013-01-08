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
        //private BtDotNetDb db = new BtDotNetDb();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "The index has loaded.";
            return View();
        }

/*        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
*/    }
}