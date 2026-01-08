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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Eğer giren kişinin rolü "A"(Admin) değilse
            if (Session["Rol"] == null || Session["Rol"].ToString() != "A")
            {
                //Onu nazikçe Ana Sayfaya (veya Login'e) şutlayacağız.
                filterContext.Result = RedirectToAction("Index", "Home");
            }

            base.OnActionExecuting(filterContext);
        }


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

            //2. Bu listeyi ViewBag çantasına koyuyoruz.
            //ViewBag: Controller'dan View'a veri taşıyan dinamik bir yapıdır.
            ViewBag.vlc = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            //Kategori seçili mi, isim yazılı mı?
            if (ModelState.IsValid)
            {
                p.IsActive = true; //Yeni eklenen ürün varsayılan olarak aktif olsun.
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //HATA VARSA BURAYA DÜŞ!
            //Dropdown listesini tekrar doldurmamız lazım, yoksa görünüm hata verir.
            //(Aşağıdaki kod Create(GET) metodundaki kodun aynısı olmalı)
            List<SelectListItem> degerler = (from i in db.Categories.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();

            ViewBag.vlc = degerler;

            return View();
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