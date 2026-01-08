using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class Order
    {
        [Key] // Birincil anahtar
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } // Sipariş tarihi
        public decimal TotalAmount { get; set; } // Toplam tutar
        public bool IsPaid { get; set; } // Ödeme alındı mı? 

        //Hangi masanın siparişi olduğu
        public int TableId { get; set; }
        public virtual Table Table { get; set; }

        //Bir siparişin içinde bir sürü yemek olabilir (Detaylar)
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}