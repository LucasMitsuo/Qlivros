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
        public ActionResult DadosReceptor(string email = "jobson@gmail.com", string login = "jobson", int idExemplar = 4, int idDoador = 3)
        {
            var result = doacaoBC.Doar(email, login, idExemplar, idDoador);

            if (result.Item1)
            {
                return View("ConfirmDoacao", result.Item2);
            }
            else
            {
                return View("~/Views/Home/Index.cshtml",result.Item2);
            }
        }
    }
}