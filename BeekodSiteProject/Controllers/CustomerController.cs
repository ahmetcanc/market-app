using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            return View(c.Customers.ToList());
        }
        public ActionResult addCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addCustomer(Customer cu)
        {
            c.Customers.Add(cu);
            cu.Transactiondate = DateTime.Now;
            c.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpPost]
        public ActionResult deleteCustomer(int id)
        {
            var find = c.Customers.Find(id);
            c.Customers.Remove(find);
            c.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpGet]
        public ActionResult editCustomer(int id)
        {
            var bul = c.Customers.Find(id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult editCustomer(Customer cu)
        {
            var data = c.Customers.Where(x => x.Id == cu.Id).SingleOrDefault();
            data.Barkod = cu.Barkod;
            data.Name = cu.Name;
            data.PhoneNumber = cu.PhoneNumber;
            data.Workplace = cu.Workplace;
            data.Mail = cu.Mail;
            data.Transactiondate = DateTime.Now;
            data.Balance = cu.Balance;
            c.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}