using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoranOtomasyonu.Models
{
    public class Category
    {
        [Key] // Birincil anahtar
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        // İlişki: Bir kategoride birden fazla ürün olabilir.
        // List yerine ICollection kullanmak Entity Framework standardı
        public virtual ICollection<Product> Products { get; set; }
    }
}