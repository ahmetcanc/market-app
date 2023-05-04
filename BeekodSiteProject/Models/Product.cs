using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeekodSiteProject.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        public string Product_Image { get; set; }

        public string Product_Name { get; set; }

        public decimal Product_Price { get; set; }
        
    }
}