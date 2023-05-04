using BeekodSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekodSiteProject.Controllers
{
    public class DenemeController : Controller
    {
        Context c = new Context();
        // GET: Deneme
        public ActionResult Index()
        {

            return View(c.Stocks.ToList());
        }


        //[HttpPost]
        //public ActionResult Index(ProductViewModel product)
        //{
        //    // product verilerini işleme kodu burada
        //    return Json(new { success = true });
        //}
        [HttpPost]
        public ActionResult Index(ProductViewModel product)
        {

            string productNamesText = string.Join(",", product.ProductNames);
            var NewSaleHistory = new SalesHistory
            {
                Name = productNamesText,
                TotalPrices = product.TotalPrice,
                DateTimes = DateTime.Now
                // diğer özellikleri de burada eşleştirin
            };

            // DbContext sınıfınızı oluşturun

            // Product nesnesini veritabanına ekleyin ve kaydedin
            c.SalesHistories.Add(NewSaleHistory);
            c.SaveChanges();


            // İşlem tamamlandıktan sonra bir dönüş yapabilirsiniz
            return RedirectToAction("Index", "Deneme");
        }

        public ActionResult SaleHistory()
        {
            var salesHistoryList = c.SalesHistories.OrderByDescending(sh => sh.DateTimes).ToList();
            return View(salesHistoryList);
        }
    }
}