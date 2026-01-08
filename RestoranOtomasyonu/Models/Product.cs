using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoranOtomasyonu.Models
{
    public class Product
    {
        [Key] // Birincil anahtar

        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; } //Ürün menüde aktif mi değil mi

        //Bir ürünün bir kategorisi olur.
        [Required(ErrorMessage = "Lütfen bir kategori seçiniz!")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}