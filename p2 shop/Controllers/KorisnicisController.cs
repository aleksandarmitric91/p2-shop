using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using p2_shop.Models;

namespace p2_shop.Controllers
{
    public class KorisnicisController : Controller
    {
        private ShopingEntities db = new ShopingEntities();

        // GET: Korisnicis
        public ActionResult Index()
        {
            return View(db.Korisnicis.ToList());
        }

        // GET: Korisnicis/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnici korisnici = db.Korisnicis.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            return View(korisnici);
        }

        // GET: Korisnicis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisnicis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Korisnik_ID,Ime,Prezime,Email,Korisničko_ime,Šifra")] Korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.Korisnicis.Add(korisnici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnici);
        }

        // GET: Korisnicis/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnici korisnici = db.Korisnicis.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            return View(korisnici);
        }

        // POST: Korisnicis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Korisnik_ID,Ime,Prezime,Email,Korisničko_ime,Šifra")] Korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnici);
        }

        // GET: Korisnicis/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnici korisnici = db.Korisnicis.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            return View(korisnici);
        }

        // POST: Korisnicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Korisnici korisnici = db.Korisnicis.Find(id);
            db.Korisnicis.Remove(korisnici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
