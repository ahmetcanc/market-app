using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeekodSiteProject.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string ImageUrl { get; set; }
        public string SalesType { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SalePrice { get; set; }
        public int Piece { get; set; }
        public DateTime StockDate { get; set; }
        public string Wholesaler { get; set; }
        public string StockGroup { get; set; }
    }
}