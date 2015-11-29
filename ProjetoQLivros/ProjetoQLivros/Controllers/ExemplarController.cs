using ProjetoQLivros.Helpers.ViewModels;
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

        [HttpGet]
        [Route("exemplares/lista/{titulo}")]
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

        [HttpGet]
        [Route("exemplares/formdoar/{idLeitor}")]
        public ActionResult FormDoar(int idLeitor)
        {
            var result = historicoBC.VerificaPropriedade(idLeitor);
            if (result.Item2)
            {
                List<SelectListItem> opcoesExemplares = new List<SelectListItem>();

                foreach (var exemplar in result.Item1)
                {
                    opcoesExemplares.Add(new SelectListItem { Text = String.Format("{0} - {1}ª Edição", exemplar.TabExemplar.TabTitulo.nmTitulo,exemplar.TabExemplar.dsEdicao), Value = exemplar.TabExemplar.idExemplar.ToString() });
                }

                DoacaoViewModel dadosRetorno = new DoacaoViewModel()
                {
                    Historicos = result.Item1,
                    OpcoesExemplares = opcoesExemplares,
                    idDoador = idLeitor,
                    Mensagem = null
                };

                return View(dadosRetorno);
            }
            else
            {
                ViewBag.SemPropriedade = "Você não possui exemplares para doar";
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public ActionResult RomperCorrente(long idLeitor)
        {
            var lista = exemplarBC.ObterPorLeitor(idLeitor);
            return View(lista);
        }

        public ActionResult PesquisarExemplar(long idExemplar = 1)
        {
            var result = exemplarBC.ObterPorid(idExemplar);
            // Caso o exemplar esteja pendente, retorna false, caso contrário, retorna verdadeiro.

            if (result.Item2)
            {
                return View("ConfirmRomper", result.Item1);
            }
            else
            {
                ViewBag.Romper = "Sua corrente não pode ser rompida! Há doação pendente. Espere o receptor elegível responder";
                return View("RomperCorrente");
            }

        }

        public ActionResult ExcluirExemplar(long idExemplar = 2, string texto = null)
        {
            if (texto == null)
            {
                ViewBag.Romper = "Registre uma justificativa";
                return View("ConfirmRomper");
            }
            else
            {
                var msg = exemplarBC.Romper(idExemplar, texto);
                return View("ConfirmSucessoRomper", msg);
            }

        }
    }
}
