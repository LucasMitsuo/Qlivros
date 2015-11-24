using ProjetoQLivros.Models.BusinessController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoQLivros.Controllers
{
    public class SalaChatController : Controller
    {
        SalaChatBusinessController salaChatBC = new SalaChatBusinessController();
        LeitorBusinessController leitorBC = new LeitorBusinessController();

        public ActionResult Lista(long idLeitor)
        {
            var listaContatos = salaChatBC.ObterContatos(idLeitor);
            return View(listaContatos);
        }

        public ActionResult FormAdicionar(long idLeitor)
        {
            var leitor = leitorBC.Obter(idLeitor);
            return View(leitor);
        }

        public ActionResult AdicionarContato(string login, long idLeitor)
        {
            var result = salaChatBC.Criar(login, idLeitor);
            if (result.Item3)
            {
                return View("ConfirmSucessoAdicionar", result.Item2);
            }
            return View("FormAdicionar", result.Item2);
        }
    }
}