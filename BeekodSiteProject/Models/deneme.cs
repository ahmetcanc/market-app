using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeekodSiteProject.Models
{
    public class deneme
    {
        [Key]
        public int Id { get; set; }
        public string product_name { get; set; }
        public string product_price { get; set; }
        public string product_id { get; set; }
        public string product_image { get; set; }
        public int product_quantity { get; set; }
        public long unique_key { get; set; }
    }
}