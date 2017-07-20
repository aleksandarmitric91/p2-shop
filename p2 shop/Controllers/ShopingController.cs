using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2_shop.Models;
using System.Net;

namespace p2_shop.Controllers
{
    public class ShopingController : Controller
    {
        ShopingEntities db = new ShopingEntities();
        Mix_Tip_Grupa_Proizvoda mix; 
        // GET: Shoping
        public ActionResult Index(string id)
        {
            mix = new Mix_Tip_Grupa_Proizvoda(db.Grupa_tipa_proizvodas.ToList(), db.Tip_Proizvodas.ToList());
            string idSviProizvodi = "";
            List<Tip_Proizvoda> tipoviProizvoda;

            var proizvodi = db.Proizvodis.Where(p => p.Active == true).ToList();

            if (id == "Svi proizvodi")
            {
                proizvodi = db.Proizvodis.Where(p => p.Active == true).ToList();
            }
            else if (id == "Akcija")
            {
                proizvodi = db.Proizvodis.Where(p => p.Active == true && p.Akcija == true).ToList();
            }
            else if (id == "Istaknuti")
            {
                proizvodi = db.Proizvodis.Where(p => p.Active == true && p.Istaknuti == true).ToList();
            }
            foreach (var item in mix.Tipovi)
            {
                if (id == item.Naziv_Tipa)
                {
                    proizvodi = db.Proizvodis.Where(p => p.Active == true && p.FK_Tip_Proizvoda == item.Tip_Proizvoda_ID).ToList();
                }
            }

            if (id!=null)
            {
                if (id.Contains(" (Svi proizvodi)"))
                {
                    proizvodi.Clear();
                    idSviProizvodi = id.Replace(" (Svi proizvodi)", "");
                    foreach (var item in mix.Grupa_listi)
                    {
                        if (idSviProizvodi == item.Naziv_grupe_tipa_proizvoda)
                        {
                            tipoviProizvoda = db.Tip_Proizvodas.Where(p => p.FK_Grupa_tipa_proizvoda == item.Grupa_tipa_proizvoda_ID).ToList();
                            foreach (var item1 in tipoviProizvoda)
                            {
                                proizvodi.AddRange(db.Proizvodis.Where(p => p.Active == true && p.FK_Tip_Proizvoda == item1.Tip_Proizvoda_ID).ToList());
                            }
                        }
                    }
                }
            }

            ViewBag.Ocjene = db.Pregledis;
            return View(proizvodi);
        }

        public ActionResult Details(long? id)
        {
            Mix_Proizvodi_Pregledi mix_proizvodi_pregledi;
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodi proizvod = db.Proizvodis.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            mix_proizvodi_pregledi = new Mix_Proizvodi_Pregledi(proizvod, db.Pregledis.ToList());
            return View(mix_proizvodi_pregledi);
        }
    }
}