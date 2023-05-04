using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class SaleHistoryController : Controller
    {
        Context c = new Context();
        // GET: SaleHistory
        public ActionResult Index()
        {
            return View(c.SalesHistories.ToList());
        }
    }
}