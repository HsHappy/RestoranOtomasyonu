using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoranOtomasyonu.Models
{
    public class RestoranContext : DbContext
    {
        // "base" kısmı Web.config dosyasında arayacağı bağlantı ismidir.
        public RestoranContext() : base("RestoranConnection")
        {
        }

        // Veritabanında oluşacak tabloları burada tanımlıyoruz.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }

    }
}