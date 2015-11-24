using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class ResenhaBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();

        public void Criar(TabResenha resenha)
        {
            db.TabResenha.Add(resenha);
            db.SaveChanges();
        }
     }

}

