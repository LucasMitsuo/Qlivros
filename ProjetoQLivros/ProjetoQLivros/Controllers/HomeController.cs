using ProjetoQLivros.Models.BusinessController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoQLivros.Controllers
{
    public class HomeController : Controller
    {
        NotificacaoBusinessController notificacaoBC = new NotificacaoBusinessController();
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index(int idLeitor)
        {
            var result = notificacaoBC.VerificaNotificacao(idLeitor);
            if (result.Item2)
            {
                Session["notificacao"] = "SIM";
            }
            return View(result.Item1);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}