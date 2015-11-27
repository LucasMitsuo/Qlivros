using ProjetoQLivros.Models.BusinessController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoQLivros.Controllers
{
    public class DoacaoController : Controller
    {
        DoacaoBusinessController doacaoBC = new DoacaoBusinessController();
        public ActionResult DadosReceptor(string email, string login, int idExemplar, int idDoador)
        {
            var result = doacaoBC.Doar(email, login, idExemplar, idDoador);

            if (result.Item1)
            {
                return View("~/Views/Doacao/ConfirmDoacao.cshtml", result.Item2);
            }
            else
            {
                return View("~/Views/Home/Index.cshtml",result.Item2);
            }
        }
    }
}