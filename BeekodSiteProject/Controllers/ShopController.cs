using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class ShopController : Controller
    {
        Context c = new Context();
        // GET: Shop
        [Authorize]
        public ActionResult Index()
        {
            return View(c.Stocks.ToList());
        }
    }
}