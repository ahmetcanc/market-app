using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BeekodSiteProject.Models
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=BeekodDB")
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<SalesHistory> SalesHistories { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
