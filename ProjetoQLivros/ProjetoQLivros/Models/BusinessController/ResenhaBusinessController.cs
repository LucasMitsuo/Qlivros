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

        public IQueryable<TabResenha> ObterPorExemplar(int idExemplar)
        {
            var listaResenha = db.TabResenha.Where(model => model.fkIdExemplar == idExemplar);
            return listaResenha;
        }

        public TabResenha ObterConteudo(int idResenha)
        {
            var resenha = db.TabResenha.Where(model => model.idResenha == idResenha).FirstOrDefault();
            return resenha;
        }
        

        public void Criar(TabResenha resenha)
        {
            db.TabResenha.Add(resenha);
            db.SaveChanges();
        }
     }
}

