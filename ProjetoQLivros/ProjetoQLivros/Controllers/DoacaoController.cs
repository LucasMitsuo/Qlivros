using ProjetoQLivros.Helpers.ViewModels;
using ProjetoQLivros.Models.BusinessController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoQLivros.Controllers
{
    public class DoacaoController : Controller
    {
        DoacaoBusinessController doacaoBC = new DoacaoBusinessController();
        HistoricoBusinessController historicoBC = new HistoricoBusinessController();
        public ActionResult DadosReceptor(string email, string login, int idExemplar, int idDoador)
        {
            var result = doacaoBC.Doar(email, login, idExemplar, idDoador);

            if (result.Item1)
            {
                return View("~/Views/Doacao/ConfirmDoacao.cshtml", new Tuple<string,int>(result.Item2,idDoador));
            }
            else
            {
                var listaExemplares = historicoBC.VerificaPropriedade(idDoador);

                List<SelectListItem> opcoesExemplares = new List<SelectListItem>();

                foreach (var exemplar in listaExemplares.Item1)
                {
                    opcoesExemplares.Add(new SelectListItem { Text = String.Format("{0} - {1}ª Edição", exemplar.TabExemplar.TabTitulo.nmTitulo, exemplar.TabExemplar.dsEdicao), Value = exemplar.TabExemplar.idExemplar.ToString() });
                }

                DoacaoViewModel dadosRetorno = new DoacaoViewModel()
                {
                    Historicos = listaExemplares.Item1,
                    OpcoesExemplares = opcoesExemplares,
                    idDoador = idDoador,
                    Mensagem = result.Item2
                };

                return View("~/Views/Exemplar/FormDoar.cshtml",dadosRetorno);
            }
        }
    }
}