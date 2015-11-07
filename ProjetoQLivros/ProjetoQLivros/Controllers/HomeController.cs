using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoQLivros.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var thays = "S2";
            //asdjashdhaskdhsad
            //asdajsdhjashdsad
            return View();
        }

        public ActionResult About()
        {

            string MitsuoTeste;
            //asdhhasdsadasd

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}