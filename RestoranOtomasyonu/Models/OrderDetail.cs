using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoranOtomasyonu.Models
{
    public class OrderDetail
    {
        [Key] // Birincil anahtar
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; } // Ürün adedi
        public decimal Price { get; set; } // Birim fiyat

        // İlişki: Hangi siparişe ait?
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        // İlişki: Hangi ürün satıldı?
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}