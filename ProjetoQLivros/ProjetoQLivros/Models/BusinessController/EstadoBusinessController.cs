using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class EstadoBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        public TabEstado ObterEstado(string estado)
        {
            var _estado = db.TabEstado.Where(model => model.nmEstado.ToLower() == estado.ToLower()).FirstOrDefault();
            return _estado;
        }
    }
}
