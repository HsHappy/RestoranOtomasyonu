using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        RestoranContext db = new RestoranContext();

        // GET: Product
        public ActionResult Index()
        {
            var values = db.Products.Include("Category").ToList(); //Ürünleri getirirken, kendi kategori tablosu ile beraber getir.
            return View(values);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // 1. Kategorileri veritabanından çekiyoruz ve Dropdown formatına çeviriyoruz.
            // SelectListItem: HTML'deki <option> etiketidir.
            // Text: Görünen isim (Örn: Çorbalar), Value: Arka plandaki değer (Örn: 1)
            List<SelectListItem> categories = (from x in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            // 2. Bu listeyi ViewBag çantasına koyuyoruz.
            // ViewBag: Controller'dan View'a veri taşıyan dinamik bir yapıdır.
            ViewBag.vlc = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            p.IsActive = true; // Yeni eklenen ürün varsayılan olarak aktif olsun.
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = db.Products.Find(id);

            db.Products.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = db.Products.Find(id);
            List<SelectListItem> categories = (from x in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.vlc = categories;
            return View(value);
        }

        [HttpPost]
        public ActionResult Update(Product p)
        {
            var value = db.Products.Find(p.ProductId);

            //Yeni Bilgiler ile değiştirme
            value.ProductName = p.ProductName;
            value.Price = p.Price;
            value.CategoryId = p.CategoryId;
            value.ImagePath = p.ImagePath;
            value.IsActive = p.IsActive;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}