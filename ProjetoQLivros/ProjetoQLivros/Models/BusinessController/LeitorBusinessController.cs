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
        public Tuple<TabLeitor,bool> VerificaLogin(TabLeitor dadosLeitor)
        {
            var leitor = db.TabLeitor.Where(model => model.dsLogin == dadosLeitor.dsLogin && model.dsSenha == dadosLeitor.dsSenha).FirstOrDefault();
            if (leitor == null)
            {
                return new Tuple<TabLeitor,bool>(null,false);
            }
            else
            {
                return new Tuple<TabLeitor, bool>(leitor, false);
            }
        }

        public IQueryable<TabLeitor> Obter(long idLeitor)
        {
            var leitor = db.TabLeitor.Where(model => model.idLeitor == idLeitor);
            return leitor;
        }
    }
}
