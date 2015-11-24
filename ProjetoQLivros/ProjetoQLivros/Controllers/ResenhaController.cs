using ProjetoQLivros.Models.BusinessController;
using ProjetoQLivros.Models.TabModels;
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
        HistoricoBusinessController historicoBC = new HistoricoBusinessController();

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

        public ActionResult FormResenha(int idLeitor)
        {
            var validaStatusExemplar = historicoBC.VerificaPropriedade(idLeitor);

            if (validaStatusExemplar.Item2) 
            {
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
