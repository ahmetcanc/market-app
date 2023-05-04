using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class StockController : Controller
    {
        Context c = new Context();
        // GET: Stock
        public ActionResult Index()
        {
            return View(c.Stocks.ToList());
        }
        public ActionResult addStock()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addStock(Stock s)
        {
            c.Stocks.Add(s);
            s.StockDate = DateTime.Now;
            c.SaveChanges();
            return RedirectToAction("Index", "Stock");
        }
        [HttpPost]
        public ActionResult deleteStock(int id)
        { 
            var find = c.Stocks.Find(id);
            c.Stocks.Remove(find);
            c.SaveChanges();
            return RedirectToAction("Index", "Stock");
        }
        [HttpGet]
        public ActionResult editStock(int id)
        {
            var bul = c.Stocks.Find(id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult editStock(Stock s)
        {
            var data = c.Stocks.Where(x => x.Id == s.Id).SingleOrDefault();
            data.Name = s.Name;
            data.Barcode = s.Barcode;
            data.ImageUrl = s.ImageUrl;
            data.SalesType = s.SalesType;
            data.PurchasePrice = s.PurchasePrice;
            data.SalePrice = s.SalePrice;
            data.Piece = s.Piece;
            data.StockDate = DateTime.Now;
            data.Wholesaler = s.Wholesaler;
            data.StockGroup = s.StockGroup;
            c.SaveChanges();
            return RedirectToAction("Index", "Stock");
        }
        
    }
}