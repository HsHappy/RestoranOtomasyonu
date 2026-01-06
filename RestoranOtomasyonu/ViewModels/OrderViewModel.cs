using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.ViewModels
{
    public class OrderViewModel
    {
        // 1. Menüyü listelemek için Kategorilere ihtiyacımız var (Ürünler içinde.)
        public List<Category> Categories { get; set; }

        // 2. O anki masanın bilgilerine ihtiyacımız var (Adı ne? ID'si ne?)
        public Table CurrentTable { get; set; }

        // 3. O masanın AÇIK olan siparişine ihtiyacımız var (Sepet)
        public Order CurrentOrder { get; set; }
    }
}