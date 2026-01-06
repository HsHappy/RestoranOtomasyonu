using RestoranOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace RestoranOtomasyonu.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // Veritabanı bağlantı nesnemizi (Context) oluşturuyoruz.
        // Bu nesne sayesinde veritabanı işlemlerini yapacağız.

        RestoranContext db = new RestoranContext();

        // GET: Category
        // Kullanıcı "/Category/Index" adresine gittiğinde bu çalışır.
        public ActionResult Index()
        {
            // Veritabanındaki Kategoriler tablosunu listeye çevirip değişkene atma.
            var values = db.Categories.ToList();

            return View(values);
        }

        // 1. GET: Sayfayı göster
        //Kullanıcı linke tıkladığında sadece formu göster.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // 2. POST: Veriyi kaydeder
        //Butona basıldığında bura çalışır.
        //Parametre olarak (Category p) alır, yani formdaki 'p' değişkenine dolar.
        [HttpPost]
        public ActionResult Create(Category p)
        {
            //Formdan gelen 'p' nesneisini veritabanı bağlamına ekle.
            db.Categories.Add(p);

            //SQL'e INSERT komutunu gönder.
            db.SaveChanges();

            //İşlem bitince Index'e yönlendir.
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //1. Silinecek kategoriyi buluyoruz
            var category = db.Categories.Find(id); //.Find() metodu birincil anahtarı arar, hızlı.

            //2. Kategoriyi Silinecekler listesine işaretleme
            db.Categories.Remove(category);

            //3. SQL'e kaydetme
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = db.Categories.Find(id);

            //Bulunan değeri sayfaya gönder.
            return View(value);
        }

        [HttpPost]
        public ActionResult Update(Category p)
        {
            var value = db.Categories.Find(p.CategoryId); //Eski kaydı bulma

            value.CategoryName = p.CategoryName; //Eski kaydın adını değiştirme

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}