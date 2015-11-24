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
    public class ResenhaController : Controller
    {
        
        
        public ActionResult FormResenha(int idLeitor)
        {
            HistoricoBusinessController histBC = new HistoricoBusinessController();

            var validaStatusExemplar = histBC.VerificaPropriedade(idLeitor);

            if (validaStatusExemplar.Item2) {

                return RedirectToAction("~/Views/Resenha/FormResenha.cshtml", validaStatusExemplar.Item1);
                }
                else
                {
                ViewBag.Erro = "Não existem exemplares para o leitor";
                return View("~/Views/Home/Index.cshtml");
                }
          }
            

        public ActionResult Publicar(TabResenha resenha)
        {
            return View("~/Views/Resenha/ConfirmPublicacao.cshtml");
        }
    }
}
