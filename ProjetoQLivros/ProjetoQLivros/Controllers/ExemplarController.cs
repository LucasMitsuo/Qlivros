using ProjetoQLivros.Models.BusinessController;
using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjetoQLivros.Controllers
{
    public class ExemplarController : Controller
    {
        ExemplarBusinessController exemplarBC = new ExemplarBusinessController();
        HistoricoBusinessController historicoBC = new HistoricoBusinessController();
        public ActionResult Lista(string titulo)
        {
            var retornoLista = exemplarBC.FiltrarTitulo(titulo);
            if (retornoLista.Count() > 0)
            {
                return View(retornoLista);
            }
            else
            {
                ViewBag.SemLista = "Não há exemplares com esse título";
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public ActionResult FormDoar(long idLeitor = 3)
        {
            var result = historicoBC.VerificaPropriedade(idLeitor);
            if (result.Item2)
            {
                return View("FormDoar", result.Item1);
            }
            else
            {
                ViewBag.SemPropriedade = "Você não possui exemplares para doar";
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }
}
