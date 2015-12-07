using ProjetoQLivros.Models.BusinessController;
using ProjetoQLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjetoQLivros.Models.TabModels;

namespace ProjetoQLivros.Controllers
{
    public class LeitorController : Controller
    {
        LeitorBusinessController leitorBC = new LeitorBusinessController();
        [HttpPost]
        [Route("qlivros/login")]
        public ActionResult Autenticar(TabLeitor leitor)
        {
            if (ModelState.IsValid)
            {
                var result = leitorBC.VerificaLogin(leitor);

                if (result.Item2)
                {
                    Session["usuario"] = result.Item1;
                    return RedirectToAction("Index", "Home", new { idLeitor = result.Item1.idLeitor });
                }
                else
                {
                    ViewBag.ErroAutentica = "Login ou senha incorretos";
                    return View("~/Views/Home/Login.cshtml");
                }
            }
            return View("~/Views/Home/Login.cshtml");
        }

        public ActionResult ConfirmCancelamento()
        {
            return View("~/Views/Leitor/ConfirmCancelamento.cshtml");
        }

        public ActionResult FormCadastro()
        {
            return View();
        }

        public ActionResult Cadastrar(TabLeitor leitor,string rua,string bairro,string cidade,string estado)
        {
            var _leitor = leitorBC.CadastrarLeitor(leitor, rua, bairro, cidade, estado);

            if (_leitor == null)
            {
                ViewBag.StatusCadastro = "Erro na hora do cadastro";
                return View();
            }
            else
            {
                ViewBag.SucessoCadastro = "Cadastro realizado com sucesso.";
                return View("~/Views/Leitor/ConfirmSucessoCadastro.cshtml");
            }
        }
    }
}
