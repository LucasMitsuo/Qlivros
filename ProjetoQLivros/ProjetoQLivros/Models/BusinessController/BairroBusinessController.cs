using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class BairroBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        CidadeBusinessController cidadeBC = new CidadeBusinessController();

        public TabBairro CriarBairro(string bairro, string cidade, string estado)
        {
            var _bairro = db.TabBairro.Where(model => model.nmBairro.ToLower() == bairro.ToLower()).FirstOrDefault();

            if (_bairro == null)
            {
                var novaCidade = cidadeBC.CriarCidade(cidade, estado);
                TabBairro novoBairro = new TabBairro();
                novoBairro.nmBairro = bairro;
                novoBairro.fkIdCidade = novaCidade.idCidade;
                novoBairro = db.TabBairro.Add(novoBairro);
                db.SaveChanges();
                return novoBairro;
            }

            return _bairro;
        }
    }
}
