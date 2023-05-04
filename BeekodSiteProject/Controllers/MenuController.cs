using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menü
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}