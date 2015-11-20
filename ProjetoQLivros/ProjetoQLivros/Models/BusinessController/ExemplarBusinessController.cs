using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class ExemplarBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        public IQueryable<TabExemplar> FiltrarTitulo(string titulo)
        {
            //Pesquisa no banco os exemplares que possuem o título informado e que estejam ativo
            var exemplares = db.TabExemplar.Where(model => model.TabTitulo.nmTitulo.ToLower() == titulo.ToLower() && model.dsStatus.Equals((int)StatusRegistroExemplar.DISPONIVEL));
            return exemplares;
        }
    }
}
