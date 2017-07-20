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
    public class ProizvodisController : Controller
    {
        private ShopingEntities db = new ShopingEntities();


        public ActionResult Kupovina()
        {
            var proizvodi = db.Proizvodis.Where(p => p.Active == true).ToList();
            return View(proizvodi);
        }


        // GET: Proizvodis
        public ActionResult Index()
        {
            var proizvodis = db.Proizvodis;
            return View(proizvodis.ToList());
        }

        // GET: Proizvodis/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodi proizvodi = db.Proizvodis.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);
        }

        // GET: Proizvodis/Create
        public ActionResult Create()
        {
            ViewBag.FK_Tip_Proizvoda = new SelectList(db.Tip_Proizvodas, "Tip_Proizvoda_ID", "Naziv_Tipa");
            return View();
        }

        // POST: Proizvodis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Proizvod_ID,Naziv,Cijena,Opis,Naziv_Slike,Active,FK_Tip_Proizvoda")] Proizvodi proizvodi)
        {
            if (ModelState.IsValid)
            {
                db.Proizvodis.Add(proizvodi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Tip_Proizvoda = new SelectList(db.Tip_Proizvodas, "Tip_Proizvoda_ID", "Naziv_Tipa", proizvodi.FK_Tip_Proizvoda);
            return View(proizvodi);
        }

        // GET: Proizvodis/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodi proizvodi = db.Proizvodis.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tip = new SelectList(db.Tip_Proizvodas, "Tip_Proizvoda_ID", "Naziv_Tipa", proizvodi.FK_Tip_Proizvoda);
            return View(proizvodi);
        }

        // POST: Proizvodis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proizvod_ID,Naziv,Cijena,Opis,Naziv_Slike,Active,FK_Tip_Proizvoda,Istaknuti,Akcija")] Proizvodi proizvodi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvodi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Tip_Proizvoda = new SelectList(db.Tip_Proizvodas, "Tip_Proizvoda_ID", "Naziv_Tipa", proizvodi.FK_Tip_Proizvoda);
            return View(proizvodi);
        }

        // GET: Proizvodis/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodi proizvodi = db.Proizvodis.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);
        }

        // POST: Proizvodis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Proizvodi proizvodi = db.Proizvodis.Find(id);
            db.Proizvodis.Remove(proizvodi);
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
