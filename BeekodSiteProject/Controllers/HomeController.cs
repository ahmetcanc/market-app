using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class HomeController : Controller
    {
        //Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        
       

    }
}