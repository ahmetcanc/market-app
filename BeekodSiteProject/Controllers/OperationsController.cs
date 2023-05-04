using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class OperationsController : Controller
    {
        Context c = new Context();
        // GET: Operations
        public ActionResult Operation()
        {
            return View();
        }
    }
}