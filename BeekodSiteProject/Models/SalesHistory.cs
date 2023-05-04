using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeekodSiteProject.Models
{
    public class SalesHistory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string TotalPrices { get; set; }
        public DateTime DateTimes { get; set; }
    }
}