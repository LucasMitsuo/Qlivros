using ProjetoQLivros.Models.BusinessController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjetoQLivros.Controllers
{
    public class ResenhaController : Controller
    {
        ResenhaBusinessController resenhaBC = new ResenhaBusinessController();
        public ActionResult Lista(int idExemplar)
        {
            
            var listaResenhas = resenhaBC.ObterPorExemplar(idExemplar);
            if (listaResenhas.Count() > 0)
            {
                return View(listaResenhas);
            }
            ViewBag.SemLista = "Não há resenhas para visualizar";
            return View("Index");
        }

        public ActionResult Info(int idResenha)
        {
            var result = resenhaBC.ObterConteudo(idResenha);
            return View(result);
        }
    }
}
