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
    public class PreglediController : Controller
    {
        private ShopingEntities db = new ShopingEntities();

        // GET: Pregledi
        public ActionResult Index()
        {
            var pregledis = db.Pregledis.Include(p => p.Proizvodi);
            return View(pregledis.ToList());
        }

        // GET: Pregledi/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregledi pregledi = db.Pregledis.Find(id);
            if (pregledi == null)
            {
                return HttpNotFound();
            }
            return View(pregledi);
        }

        // GET: Pregledi/Create
        //public ActionResult Create()
        //{
        //    ViewBag.FK_Proizvod_ID = new SelectList(db.Proizvodis, "Proizvod_ID", "Naziv");
        //    return View();
        //}

        // GET: Pregledi/Create/id
        public ActionResult Create(int id)
        {
            if (id == 0)
            {
                ViewBag.FK_Proizvod_ID = new SelectList(db.Proizvodis, "Proizvod_ID", "Naziv");
            }
            else
            {
                IEnumerable<Proizvodi> rezultat = db.Proizvodis.Where(b => b.Proizvod_ID == id);
                ViewBag.FK_Proizvod_ID = new SelectList(rezultat, "Proizvod_ID", "Naziv");
            }
            return View();
        }

        // POST: Pregledi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pregled_ID,Ocjena,Komentar,FK_Proizvod_ID")] Pregledi pregledi)
        {
            try
            {
                if (Session["Korisničko_ime"].ToString() != "")
                {
                    pregledi.Pregledac = Session["Korisničko_ime"].ToString();
                }
            }
            catch (Exception)
            {
                pregledi.Pregledac = "<Anonimno lice>";
            }
            pregledi.Datum_ocjenjivanja = System.DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                db.Pregledis.Add(pregledi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Proizvod_ID = new SelectList(db.Proizvodis, "Proizvod_ID", "Naziv", pregledi.FK_Proizvod_ID);
            return View(pregledi);
        }

        // GET: Pregledi/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregledi pregledi = db.Pregledis.Find(id);
            if (pregledi == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Proizvod_ID = new SelectList(db.Proizvodis, "Proizvod_ID", "Naziv", pregledi.FK_Proizvod_ID);
            return View(pregledi);
        }

        // POST: Pregledi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pregled_ID,Pregledac,Ocjena,Komentar,Datum_ocjenjivanja,FK_Proizvod_ID")] Pregledi pregledi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregledi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Proizvod_ID = new SelectList(db.Proizvodis, "Proizvod_ID", "Naziv", pregledi.FK_Proizvod_ID);
            return View(pregledi);
        }

        // GET: Pregledi/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregledi pregledi = db.Pregledis.Find(id);
            if (pregledi == null)
            {
                return HttpNotFound();
            }
            return View(pregledi);
        }

        // POST: Pregledi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Pregledi pregledi = db.Pregledis.Find(id);
            db.Pregledis.Remove(pregledi);
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
