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
    public class HistoricoController : Controller
    {
        HistoricoBusinessController historicoBC = new HistoricoBusinessController();
        NotificacaoBusinessController notificacaoBC = new NotificacaoBusinessController();
        public ActionResult AcompanharHistorico(long idLeitor)
        {

            if (historicoBC.ObterLidos(idLeitor).Count() == 0)
            {
                ViewBag.HistNulo("Você não possui históricos.");
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {

                return View("AcompanharHistorico", historicoBC.ObterLidos(idLeitor));
            }
        }
        public ActionResult VisualizarHistorico(long idExemplar)
        {
            var historico = historicoBC.ListaHistorico(idExemplar);
            return View("VisualizarHistorico", historico);
        }

        public ActionResult Lista(int idLeitor)
        {
            var lista = notificacaoBC.ObterLista(idLeitor);
            Session["notificacao"] = "NAO";
            return View(lista);
        }

        public ActionResult Info(int idHistorico = 14)
        {
            var notificacao = notificacaoBC.Detalhes(idHistorico);
            return View(idHistorico);
        }

        public ActionResult Resultado(int idReceptor,int idDoador, int idExemplar, string resposta)
        {
            var resultado = historicoBC.VerificaResposta(idReceptor, idDoador, idExemplar, resposta);
            return View("RespNotificacao", resultado);
        }
    }
}
