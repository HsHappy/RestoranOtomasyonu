using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        RestoranContext db = new RestoranContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "A")
            {
                filterContext.Result = RedirectToAction("Index", "Home");
            }
            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            // Kayıtları tarihe göre tersten sıralama (En son yapılan işlem en üstte)
            var logs = db.ActionLogs.OrderByDescending(x => x.Date).ToList();
            return View(logs);
        }
    }
}