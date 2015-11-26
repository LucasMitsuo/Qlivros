using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoQLivros.Models.BusinessController
{
    public class NotificacaoBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        private Tuple<List<TabHistorico>,bool> ObterNotificacoes(int idLeitor)
        {
            List<TabHistorico> historicos = new List<TabHistorico>();
            //Verifica se o leitor possui algum registro na tabela histórico com status PENDENTE. Porém, isso não garante que todos 
            //os registros retornados NÃO TENHAM SIDO RESPONDIDOS
            var pendentes = db.TabHistorico.Where(model => model.fkIdReceptor == idLeitor && model.dsStatus == (int)EnumStatusHistorico.PENDENTE);
            foreach (var registro in pendentes)
            {
                //Verifica se o registro já foi aceito ou recusado, pois se já foi um dos dois, ele não pode ser adicionado
                // à lista de notificações
                var respondido = db.TabHistorico.Where(model => model.fkIdExemplar == registro.fkIdExemplar && model.fkIdReceptor == idLeitor && (model.dsStatus == (int)EnumStatusHistorico.ACEITO || model.dsStatus == (int)EnumStatusHistorico.RECUSADO)).ToList();
                if (respondido.Count() == 0)
                {
                    historicos.Add(registro);
                }
            }

            if (historicos.Count() > 0)
            {
                return new Tuple<List<TabHistorico>,bool>(historicos,true);
            }
            else
            {
                return new Tuple<List<TabHistorico>, bool>(null, false);
            }
        }

        public bool VerificaNotificacao(int idLeitor)
        {
            return this.ObterNotificacoes(idLeitor).Item2;
        }

        public List<TabHistorico> ObterLista(int idLeitor)
        {
            var lista = this.ObterNotificacoes(idLeitor).Item1;
            return lista;
        }

        public TabHistorico Detalhes(int idHistorico)
        {
            return db.TabHistorico.Where(model => model.idHistorico == idHistorico).FirstOrDefault();
        }
    }
}