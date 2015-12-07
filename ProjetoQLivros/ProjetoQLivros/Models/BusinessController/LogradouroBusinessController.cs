using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class LogradouroBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        BairroBusinessController bairroBC = new BairroBusinessController();
        public TabLogradouroEnd CriarEndereco(string endereco,string bairro, string cidade, string estado)
        {
            var _endereco = db.TabLogradouroEnd.Where(model => model.nmLogradouro.ToLower() == endereco.ToLower()).FirstOrDefault();

            if (_endereco == null)
            {
                var novoBairro = bairroBC.CriarBairro(bairro, cidade, estado);
                TabLogradouroEnd novoEndereco = new TabLogradouroEnd();
                novoEndereco.nmLogradouro = endereco;
                novoEndereco.fkIdBairro = novoBairro.idBairro;
                novoEndereco = db.TabLogradouroEnd.Add(novoEndereco);
                db.SaveChanges();
                return novoEndereco;
            }
            return _endereco;
        }
    }
}
