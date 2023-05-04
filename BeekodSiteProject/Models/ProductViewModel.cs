using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeekodSiteProject.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        public string[] ProductNames { get; set; }
        public int[] Quantities { get; set; }
        public string TotalPrice { get; set; }
    }
}