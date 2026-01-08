using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoranOtomasyonu.Models;
using RestoranOtomasyonu.ViewModels;

namespace RestoranOtomasyonu.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        //Garson Operasyonları için kullanılacak.

        RestoranContext db = new RestoranContext();

        //Masalar Burada Gözükecek.
        public ActionResult Index()
        {
            //Tüm masalar listeye alındı ve görünüme gönderildi.
            var tables = db.Tables.ToList();
            return View(tables);
        }

        [HttpGet]
        public ActionResult TableDetails(int id)
        {
            OrderViewModel model = new OrderViewModel();

            //Menüyü dolduruyoruz(Kategoriler ve içindeki Ürünler)
            model.Categories = db.Categories.Include("Products").ToList();

            //Masayı Bulma
            model.CurrentTable = db.Tables.Find(id);

            // Bu masanın daha önce açılmış, HENÜZ ÖDENMEMİŞ bir siparişi var mı?
            // FirstOrDefault: Varsa getirir, yoksa 'null' (boş) getirir.
            // IsPaid == false (Hesabı ödenmemiş) ve TableId == id (Bu masaya ait)
            var activeOrder = db.Orders.FirstOrDefault(x => x.TableId == id && x.IsPaid == false);

            model.CurrentOrder = activeOrder;

            return View(model);
        }
        
        [HttpGet]
        public ActionResult AddProduct(int productId, int tableId)
        {
            var table = db.Tables.Find(tableId);
            var product = db.Products.Find(productId);

            //Bu masanın AÇIK (Ödenmemiş) bir siparişi var mı?
            var activeOrder = db.Orders.FirstOrDefault(x => x.TableId == tableId && x.IsPaid == false);

            //Masada henüz sipariş yoksa (Masa yeni açılıyor)
            if (activeOrder == null)
            {
                activeOrder = new Order()
                {
                    TableId = tableId,
                    OrderDate = System.DateTime.Now,
                    IsPaid = false,
                    TotalAmount = 0 //Başlangıçta toplam tutar 0
                };

                db.Orders.Add(activeOrder);
                db.SaveChanges(); //Kaydetti ki OrderId oluşsun.

                //Masayı dolu olarak işaretleme
                table.IsOccupied = true;
                db.SaveChanges();
            }

            //Sipariş zaten var veya yeni oluşturuldu. Şimdi ürünü içine atalım.

            // Bu siparişin içinde bu üründen daha önce eklenmiş mi?
            var orderDetail = db.OrderDetails.FirstOrDefault(x => x.OrderId == activeOrder.OrderId && x.ProductId == productId);

            if (orderDetail != null)
            {
                //Ürün zaten var, miktarını artır.
                orderDetail.Quantity += 1;

                //Toplam tutarı artır.
                activeOrder.TotalAmount += product.Price;
            }
            else
            {
                //Ürün ilk defa eklendi.
                orderDetail = new OrderDetail()
                {
                    OrderId = activeOrder.OrderId,
                    ProductId = productId,
                    Quantity = 1,
                    Price = product.Price //Fiyatı o anki fiyattan sabitliyoruz
                };

                db.OrderDetails.Add(orderDetail);

                //Toplam tutarı artır.
                activeOrder.TotalAmount += product.Price;
            }

            db.SaveChanges();

            //Sipariş Loglama
            ActionLog log = new ActionLog();
            log.PersonelName = Session["Ad"].ToString();
            log.ActionType = "Sipariş";
            log.Date = DateTime.Now;
            log.Description = "Masa " + tableId + " için yeni sipariş oluşturuldu.";

            db.ActionLogs.Add(log);
            db.SaveChanges();

            return RedirectToAction("TableDetails", new { id = tableId });
        }

        [HttpGet]
        public ActionResult CloseOrder(int tableId)
        {
            var table = db.Tables.Find(tableId);

            //O masanın ödenmemiş aktif siparişini bul
            var activeOrder = db.Orders.FirstOrDefault(x => x.TableId == tableId && x.IsPaid == false);

            if (activeOrder != null)
            {
                //Siparişi kapama
                activeOrder.IsPaid = true;

                //Masayı boşa çıkarma
                table.IsOccupied = false;

                db.SaveChanges();
            }

            //Hesap loglama
            ActionLog log = new ActionLog();
            log.PersonelName = Session["Ad"].ToString();
            log.ActionType = "Hesap Ödeme";
            log.Date = DateTime.Now;
            log.Description = tableId + " numaralı masa hesabı alındı ve kapatıldı.";

            db.ActionLogs.Add(log);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}