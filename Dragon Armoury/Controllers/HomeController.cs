using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dragon_Armoury.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            ViewBag.Message = "Feel free to contact Dragon Armoury, were happy to help in any way we can with any questions you may have.";

            return View();
        }

        public ActionResult Weapons()
        {
            ViewBag.Catagory = 1;
            ViewBag.Title = "Weapons";
            ViewBag.Message = "Dragon Armoury makes an array of high quality LARP safe weapons. So what ever your character Dragon Armoury has something for you.";

            return View();
        }

        public ActionResult Armour()
        {
            ViewBag.Catagory = 2;
            ViewBag.Title = "Armour";
            ViewBag.Message = "Dragon Armoury makes an array of high quality LARP Armour. So what ever your character Dragon Armoury has something for you.";

            return View();
        }
    }
}