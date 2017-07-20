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
    public class Grupa_tipa_proizvodaController : Controller
    {
        private ShopingEntities db = new ShopingEntities();

        // GET: Grupa_tipa_proizvoda
        public ActionResult Index()
        {
            return View(db.Grupa_tipa_proizvodas.ToList());
        }

        // GET: Grupa_tipa_proizvoda/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa_tipa_proizvoda grupa_tipa_proizvoda = db.Grupa_tipa_proizvodas.Find(id);
            if (grupa_tipa_proizvoda == null)
            {
                return HttpNotFound();
            }
            return View(grupa_tipa_proizvoda);
        }

        // GET: Grupa_tipa_proizvoda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupa_tipa_proizvoda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Grupa_tipa_proizvoda_ID,Naziv_grupe_tipa_proizvoda")] Grupa_tipa_proizvoda grupa_tipa_proizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Grupa_tipa_proizvodas.Add(grupa_tipa_proizvoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupa_tipa_proizvoda);
        }

        // GET: Grupa_tipa_proizvoda/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa_tipa_proizvoda grupa_tipa_proizvoda = db.Grupa_tipa_proizvodas.Find(id);
            if (grupa_tipa_proizvoda == null)
            {
                return HttpNotFound();
            }
            return View(grupa_tipa_proizvoda);
        }

        // POST: Grupa_tipa_proizvoda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Grupa_tipa_proizvoda_ID,Naziv_grupe_tipa_proizvoda")] Grupa_tipa_proizvoda grupa_tipa_proizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupa_tipa_proizvoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupa_tipa_proizvoda);
        }

        // GET: Grupa_tipa_proizvoda/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa_tipa_proizvoda grupa_tipa_proizvoda = db.Grupa_tipa_proizvodas.Find(id);
            if (grupa_tipa_proizvoda == null)
            {
                return HttpNotFound();
            }
            return View(grupa_tipa_proizvoda);
        }

        // POST: Grupa_tipa_proizvoda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Grupa_tipa_proizvoda grupa_tipa_proizvoda = db.Grupa_tipa_proizvodas.Find(id);
            db.Grupa_tipa_proizvodas.Remove(grupa_tipa_proizvoda);
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

        // GET: Grupa_tipa_proizvoda/Create
        public ActionResult Create_Modal_GTP()
        {
            return PartialView();
        }

        // POST: Grupa_tipa_proizvoda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Modal_GTP([Bind(Include = "Grupa_tipa_proizvoda_ID,Naziv_grupe_tipa_proizvoda")] Grupa_tipa_proizvoda grupa_tipa_proizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Grupa_tipa_proizvodas.Add(grupa_tipa_proizvoda);
                db.SaveChanges();
                return RedirectToAction("Create","Proizvodis");
            }

            return View(grupa_tipa_proizvoda);
        }
    }
}
