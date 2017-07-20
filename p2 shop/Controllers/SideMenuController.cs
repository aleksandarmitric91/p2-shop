using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2_shop.Models;

namespace p2_shop.Controllers
{
    public class SideMenuController : Controller
    {
        ShopingEntities db = new ShopingEntities();

        // GET: SideMenu
        public ActionResult Index()
        {
            Mix_Tip_Grupa_Proizvoda mix = new Mix_Tip_Grupa_Proizvoda(db.Grupa_tipa_proizvodas.ToList(), db.Tip_Proizvodas.ToList());
            return PartialView(mix);
        }
    }
}