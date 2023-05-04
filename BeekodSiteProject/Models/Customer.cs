using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeekodSiteProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Barkod { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Workplace { get; set; }
        public string Mail { get; set; }
        public DateTime Transactiondate { get; set; }
        public int Balance { get; set; }
    }
}