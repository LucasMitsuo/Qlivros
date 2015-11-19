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
    }
}
