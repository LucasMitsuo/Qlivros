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
            if (notificacaoBC.VerificaNotificacao(idLeitor))
            {
                ViewBag.TemNotificacao = "SIM";
            }
            return View();
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