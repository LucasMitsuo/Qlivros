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
        LeitorBusinessController leitorBC = new LeitorBusinessController();

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
                return View("~/Views/Home/Index.cshtml",result.Item3);
            }
        }

        public ActionResult RomperCorrente(int idLeitor)
        {
            //Retorna uma lista com os exemplares que o leitor é proprietário.
            var result = exemplarBC.ObterPorLeitor(idLeitor);
            if (result.Item2)
            {
                return View(new Tuple<List<TabHistorico>, int>(result.Item1, idLeitor));
            }
            ViewBag.ErroRomper = "Não há exemplares para romper corrente";
            return View("~/Views/Home/Index.cshtml", idLeitor);
        }

        public ActionResult PesquisarExemplar(long idExemplar,int idLeitor)
        {
            var result = exemplarBC.ObterPorid(idExemplar);

            if (result.Item2)
            {
                return View("ConfirmRomper", new Tuple<TabExemplar,int>(result.Item1,idLeitor));
            }
            else
            {
                ViewBag.Romper = "Sua corrente não pode ser rompida! Há doação pendente. Espere o receptor elegível responder";
                return View("RomperCorrente");
            }

        }

        public ActionResult ExcluirExemplar(int idExemplar, string texto,int idLeitor)
        {
            var result = exemplarBC.Romper(idExemplar, texto);

            if (texto.Length > 10 && texto.Length < 200)
            {
                ViewBag.ErroObs = "A justificativa deve ter entre 10 a 200 caracteres";
                return View("ConfirmRomper", new Tuple<TabExemplar, int>(result.Item1, idLeitor));
            }
            else if (texto == "")
            {
                ViewBag.ErroObs = "Informe a justificativa";
                return View("ConfirmRomper", new Tuple<TabExemplar, int>(result.Item1, idLeitor));
            }
                
            return View("ConfirmSucessoRomper",new Tuple<String,int>(result.Item2,idLeitor));
        }

        public ActionResult FormDisponibilizar(int idLeitor)
        {
            var result = exemplarBC.ObterIndisponiveis(idLeitor);
            if (result.Item2)
            {
                return View(new Tuple<List<TabHistorico>,int>(result.Item1,idLeitor));
            }
            else
            {
                ViewBag.Disp = "Você não possui exemplares indisponíveis";
                return View("~/Views/Home/Index.cshtml");
            }

        }
        public ActionResult Disponibilizar (long idExemplar,int idLeitor)
        {
            var result = exemplarBC.ObterPorIdDisp(idExemplar);
            return View("ConfirmDisponibilizar",new Tuple<TabExemplar,int>(result,idLeitor));
        }

        public ActionResult AlterarStatus(long idExemplar,int idLeitor)
        {
            var msg = exemplarBC.Alterar(idExemplar);

            if (msg == "")
            {
                ViewBag.erro = "Esse exemplar está pendente";
                var result = exemplarBC.ObterIndisponiveis(idLeitor);
                return View("FormDisponibilizar", new Tuple<List<TabHistorico>, int>(result.Item1, idLeitor));
            }
            else
            {
                return PartialView("ConfirmSucessoDisponibilizar", new Tuple<String, int>(msg, idLeitor));
            }
        }

        public ActionResult ComecarCorrente(int idLeitor)
        {
            var leitor = leitorBC.Obter(idLeitor); 
            return View(new Tuple<TabExemplar,TabLeitor>(null,leitor));
        }

        public ActionResult Cadastrar(TabExemplar exemplar, string titulo,int idLeitor)
        {
            var leitor = leitorBC.Obter(idLeitor);
            if (ModelState.IsValid)
            {
                var result = exemplarBC.Criar(exemplar, titulo, idLeitor);
                return View("~/Views/Exemplar/ConfirmSucessoCriarExemplar.cshtml",new Tuple<String,int>(result.Item2,idLeitor));
            }
            return View("ComecarCorrente", new Tuple<TabExemplar, TabLeitor>(exemplar, leitor));
        }
    }
}
