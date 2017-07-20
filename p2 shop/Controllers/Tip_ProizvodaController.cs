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
    public class Tip_ProizvodaController : Controller
    {
        private ShopingEntities db = new ShopingEntities();

        // GET: Tip_Proizvoda
        public ActionResult Index()
        {
            return View(db.Tip_Proizvodas.ToList());
        }

        // GET: Tip_Proizvoda/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip_Proizvoda tip_Proizvoda = db.Tip_Proizvodas.Find(id);
            if (tip_Proizvoda == null)
            {
                return HttpNotFound();
            }
            return View(tip_Proizvoda);
        }

        // GET: Tip_Proizvoda/Create
        public ActionResult Create()
        {
            ViewBag.FK_Grupa_tipa_proizvoda = new SelectList(db.Grupa_tipa_proizvodas, "Grupa_tipa_proizvoda_ID", "Naziv_grupe_tipa_proizvoda");
            return View();
        }

        // POST: Tip_Proizvoda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tip_Proizvoda_ID,Naziv_Tipa,FK_Grupa_tipa_proizvoda")] Tip_Proizvoda tip_Proizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Tip_Proizvodas.Add(tip_Proizvoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Grupa_tipa_proizvoda = new SelectList(db.Grupa_tipa_proizvodas, "Grupa_tipa_proizvoda_ID", "Naziv_grupe_tipa_proizvoda", tip_Proizvoda.FK_Grupa_tipa_proizvoda);
            return View(tip_Proizvoda);
        }

        // GET: Tip_Proizvoda/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip_Proizvoda tip_Proizvoda = db.Tip_Proizvodas.Find(id);
            if (tip_Proizvoda == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Grupa_tipa_proizvoda = new SelectList(db.Grupa_tipa_proizvodas, "Grupa_tipa_proizvoda_ID", "Naziv_grupe_tipa_proizvoda", tip_Proizvoda.FK_Grupa_tipa_proizvoda);
            return View(tip_Proizvoda);
        }

        // POST: Tip_Proizvoda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tip_Proizvoda_ID,Naziv_Tipa,FK_Grupa_Tipa_Proizvoda")] Tip_Proizvoda tip_Proizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tip_Proizvoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Grupa_tipa_proizvoda = new SelectList(db.Grupa_tipa_proizvodas, "Grupa_tipa_proizvoda_ID", "Naziv_grupe_tipa_proizvoda", tip_Proizvoda.FK_Grupa_tipa_proizvoda);
            return View(tip_Proizvoda);
        }

        // GET: Tip_Proizvoda/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip_Proizvoda tip_Proizvoda = db.Tip_Proizvodas.Find(id);
            if (tip_Proizvoda == null)
            {
                return HttpNotFound();
            }
            return View(tip_Proizvoda);
        }

        // POST: Tip_Proizvoda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tip_Proizvoda tip_Proizvoda = db.Tip_Proizvodas.Find(id);
            db.Tip_Proizvodas.Remove(tip_Proizvoda);
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

        public ActionResult Create_Modal()
        {
            ViewBag.FK_Grupa_tipa_proizvoda = new SelectList(db.Grupa_tipa_proizvodas, "Grupa_tipa_proizvoda_ID", "Naziv_grupe_tipa_proizvoda");
            return PartialView();
        }

        // POST: Tip_Proizvoda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Modal([Bind(Include = "Tip_Proizvoda_ID,Naziv_Tipa,FK_Grupa_tipa_proizvoda")] Tip_Proizvoda tip_Proizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Tip_Proizvodas.Add(tip_Proizvoda);
                db.SaveChanges();
                return RedirectToAction("Create","Proizvodis");
            }

            ViewBag.FK_Grupa_tipa_proizvoda = new SelectList(db.Grupa_tipa_proizvodas, "Grupa_tipa_proizvoda_ID", "Naziv_grupe_tipa_proizvoda", tip_Proizvoda.FK_Grupa_tipa_proizvoda);
            return View(tip_Proizvoda);
        }
    }
}
