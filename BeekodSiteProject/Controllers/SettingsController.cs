using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class SettingsController : Controller
    {
        Context c = new Context();
        // GET: Settings
        public ActionResult Setting()
        {
            return View(c.Admins.ToList());
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Admin a)
        {
            c.Admins.Add(a);
            c.SaveChanges();
            return RedirectToAction("Setting", "Settings");
        }

        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var bul = c.Admins.Find(id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult UpdateUser(Admin a)
        {
            var data = c.Admins.Where(x => x.Id == a.Id).SingleOrDefault();
            data.KullaniciAdi = a.KullaniciAdi;
            data.Sifre = a.Sifre;
            c.SaveChanges();
            return RedirectToAction("Setting", "Settings");
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var find = c.Admins.Find(id);
            c.Admins.Remove(find);
            c.SaveChanges();
            return RedirectToAction("Setting", "Settings");
        }

        

    }
}