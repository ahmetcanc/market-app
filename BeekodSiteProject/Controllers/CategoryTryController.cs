using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class CategoryTryController : Controller
    {
        Context c = new Context();
        // GET: CategoryTry
        public ActionResult Index()
        {
            return View(c.Stocks.ToList());
        }
    }
}