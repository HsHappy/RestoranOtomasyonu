using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        RestoranContext db = new RestoranContext();
        
        //1. Listeleme
        public ActionResult Index()
        {
            var values = db.Tables.ToList();
            return View(values);
        }

        //2. Ekleme(Getir)
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //2. Ekleme(Kaydet)
        [HttpPost]
        public ActionResult Create(Table p)
        {
            p.IsOccupied = false;
            db.Tables.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //3. Silme
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var value = db.Tables.Find(id);
            db.Tables.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //4. Güncelleme(Getir)
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = db.Tables.Find(id);
            return View(value);
        }

        //4. Güncelleme(Kaydet)
        [HttpPost]
        public ActionResult Update(Table p)
        {
            var value = db.Tables.Find(p.TableId);
            value.TableNumber = p.TableNumber;

            // Masanın durumunu (Dolu/Boş) buradan da değiştirebilmek bazen hayat kurtarır.
            // Örneğin sistem kilitlenirse admin buradan masayı boşa çekebilir.
            value.IsOccupied = p.IsOccupied;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}