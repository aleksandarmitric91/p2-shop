using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2_shop.Controllers
{
    public class StartPageController : Controller
    {
        // GET: MainPage
        public ActionResult Index()
        {
            return View();
        }
    }
}