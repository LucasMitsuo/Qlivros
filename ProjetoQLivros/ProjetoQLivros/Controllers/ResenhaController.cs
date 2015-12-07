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
            var result = resenhaBC.VerificaPropriedade(idLeitor);

            List<SelectListItem> opcoesExemplares = new List<SelectListItem>();
            List<SelectListItem> opcoesTipoResenha = new List<SelectListItem>();

            if (result.Item2) 
            {
                foreach (var exemplar in result.Item1)
                {
                    opcoesExemplares.Add(new SelectListItem { Text = String.Format("{0} - {1}ª Edição", exemplar.TabExemplar.TabTitulo.nmTitulo, exemplar.TabExemplar.dsEdicao), Value = exemplar.TabExemplar.idExemplar.ToString() });
                }

                opcoesTipoResenha.Add(new SelectListItem { Text = "Conteúdo", Value = "1" });
                opcoesTipoResenha.Add(new SelectListItem { Text = "Estado de uso", Value = "2" });

                return View("~/Views/Resenha/FormResenha.cshtml", new Tuple<List<SelectListItem>,List<SelectListItem>,int>(opcoesExemplares,opcoesTipoResenha,idLeitor));
            }
            else
            {
                ViewBag.ErroResenha = "Você não é proprietário de nenhum exemplar. Impossível publicar resenha";
                return View("~/Views/Home/Index.cshtml");
            }
        }
            
        public ActionResult Publicar(TabResenha resenha,int idLeitor)
        {
            resenhaBC.Criar(resenha);
            return View("~/Views/Resenha/ConfirmPublicacao.cshtml",new Tuple<String,int>("Resenha criada com sucesso",idLeitor));
        }
    }
}
