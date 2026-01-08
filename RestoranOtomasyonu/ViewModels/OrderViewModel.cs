using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.ViewModels
{
    public class OrderViewModel
    {
        //Menüyü listelemek için Kategorilere ihtiyacımız var (Ürünler içinde.)
        public List<Category> Categories { get; set; }

        //O anki masanın bilgilerine ihtiyacımız var (Adı ne? ID'si ne?)
        public Table CurrentTable { get; set; }

        //O masanın AÇIK olan siparişine ihtiyacımız var (Sepet)
        public Order CurrentOrder { get; set; }
    }
}