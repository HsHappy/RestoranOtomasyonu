using RestoranOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RestoranOtomasyonu.Controllers
{
    public class AccountController : Controller
    {
        RestoranContext db = new RestoranContext();

        //Login sayfasını gösterir.
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Giriş işlemi
        [HttpPost]
        public ActionResult Login(Personel p)
        {
            var user = db.Personels.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);

            if (user != null)
            {
                //Kullanıcı bulundu.
                // Sisteme "Bu kişi güvenilirdir" diye çerez (cookie) bırakıyoruz.
                // false: "Beni Hatırla" kapalı (Tarayıcı kapanınca çıkış yapsın).
                FormsAuthentication.SetAuthCookie(user.Username, false);

                Session["Rol"] = user.Role; //Rolü hafızaya attık.
                Session["Ad"] = user.Name; //Hoşgeldin mesajı için ismi alıyoruz

                // Artık Home (Ana Sayfa) içindeki Index'e gidiyoruz.
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Kullanıcı yok ise veya şifre yanlış ise
                ViewBag.Mesaj = "Kullancı Adı veya Şifre Hatalı!";
                return View();
            }
        }

        //Çıkış Yap
        public ActionResult LogOut()
        {
            //Çerezi sil ve terket
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}