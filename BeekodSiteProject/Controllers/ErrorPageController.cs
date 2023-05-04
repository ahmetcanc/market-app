using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult Error(int id)
        {
            Response.StatusCode = id;
            Response.TrySkipIisCustomErrors = true;
            ViewBag.error = id;
            return View();
        }
    }
}