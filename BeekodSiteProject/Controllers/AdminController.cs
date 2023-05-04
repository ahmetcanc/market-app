using BeekodSiteProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BeekodSiteProject.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin

        public ActionResult Login()
        {
            return View();
        }

        public class testModel
        {
            public string product_name { get; set; }
            public string product_price { get; set; }
            public string product_id { get; set; }
            public string product_image { get; set; }
            public string product_quantity { get; set; }
            public string unique_key { get; set; }
        }

        public class asilModel
        {
            public testModel[] cart_list { get; set; }
        }

        public class bayaTestModel
        {
            public string Ad { get; set; }
        }


        [HttpPost]
        public JsonResult ode(FormCollection fc)
        {
            //var res = new deneme();
            //res.Message = "ok";
            var cartListJson = fc["cart_list"];
            var cartList = JsonConvert.DeserializeObject<List<deneme>>(cartListJson);
            var subtotal = fc["subtotal"];

            return Json(cartList,subtotal, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = c.Admins.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre);

            if (login != null)
            {
                Session["adminid"] = login.Id;
                FormsAuthentication.SetAuthCookie(login.KullaniciAdi, false);
                Session["KullaniciAdi"] = login.KullaniciAdi;
                return RedirectToAction("Index", "Menu");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }
      

    }
}

