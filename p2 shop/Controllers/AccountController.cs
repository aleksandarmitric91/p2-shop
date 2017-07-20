using p2_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2_shop.Controllers
{
    public class AccountController : Controller
    {
        private ShopingEntities db = new ShopingEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Korisnici korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisnicis.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index", "Shoping");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Korisnici korisnik)
        {
            if (ModelState.IsValid)
            {
                var detalji = (from userlist in db.Korisnicis
                               where userlist.Korisničko_ime == korisnik.Korisničko_ime && userlist.Šifra == korisnik.Šifra
                               select new
                               {
                                   userlist.Korisnik_ID,
                                   userlist.Korisničko_ime,
                                   userlist.Admin
                               }).ToList();
                if (detalji.FirstOrDefault() != null)
                {
                    Session["Korisnik_ID"] = detalji.FirstOrDefault().Korisnik_ID;
                    Session["Korisničko_ime"] = detalji.FirstOrDefault().Korisničko_ime;
                    Session["Admin"] = detalji.FirstOrDefault().Admin;
                    return RedirectToAction("Welcome");
                }
            }
            else
            {
                ModelState.AddModelError("", "Pogrešne informacije");
            }
            return View(korisnik);
        }

        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult LoginMenu()
        {
            return PartialView();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Shoping");
        }

        public ActionResult Administracija()
        {
            return View();
        }
    }
}