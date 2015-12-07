using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    
    public class CidadeBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        EstadoBusinessController estadoBC = new EstadoBusinessController();
        public TabCidade CriarCidade(string cidade,string estado)
        {
            var _cidade = db.TabCidade.Where(model => model.nmCidade.ToLower() == cidade.ToLower()).FirstOrDefault();

            //Se a cidade ainda não estiver no banco, cria-se um novo objeto cidade e o retorna
            if (_cidade == null)
            {
                var _estado = estadoBC.ObterEstado(estado);
                TabCidade novaCidade = new TabCidade();
                novaCidade.nmCidade = cidade;
                novaCidade.fkIdEstado = _estado.idEstado;
                novaCidade = db.TabCidade.Add(novaCidade);
                db.SaveChanges();
                return novaCidade;
            }

            return _cidade;
            
        }
    }
}
