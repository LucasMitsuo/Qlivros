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
        public ActionResult Autenticar(TabLeitor leitor)
        {
            if (ModelState.IsValid)
            {
                if (leitorBC.VerificaLogin(leitor))
                {
                    return View("~/Views/Home/Index.cshtml",leitor);
                }
                else
                {
                    ViewBag.ErroAutentica = "Login ou senha incorretos";
                    return View("~/Views/Home/Login.cshtml");
                }
            }
            return View("~/Views/Home/Login.cshtml", leitor);
        }
    }
}
