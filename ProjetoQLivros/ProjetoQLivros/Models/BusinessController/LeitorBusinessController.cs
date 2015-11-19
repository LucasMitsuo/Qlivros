using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class LeitorBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        public bool VerificaLogin(TabLeitor leitor)
        {
            var dadosLogin = db.TabLeitor.Where(model => model.dsLogin == leitor.dsLogin && model.dsSenha == leitor.dsSenha).FirstOrDefault();
            if (dadosLogin == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
