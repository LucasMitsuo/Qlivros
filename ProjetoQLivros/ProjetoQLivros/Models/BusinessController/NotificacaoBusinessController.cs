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
        private Tuple<TabLeitor,List<TabHistorico>,bool> ObterNotificacoes(int idLeitor)
        {
            var leitor = db.TabLeitor.Where(model => model.idLeitor == idLeitor).FirstOrDefault();

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
                return new Tuple<TabLeitor,List<TabHistorico>,bool>(leitor,historicos,true);
            }
            else
            {
                return new Tuple<TabLeitor, List<TabHistorico>, bool>(null,null, false);
            }
        }

        public Tuple<TabLeitor,bool> VerificaNotificacao(int idLeitor)
        {
            var result = this.ObterNotificacoes(idLeitor);
            return new Tuple<TabLeitor, bool>(result.Item1, result.Item3);
        }

        public List<TabHistorico> ObterLista(int idLeitor)
        {
            var lista = this.ObterNotificacoes(idLeitor).Item2;
            return lista;
        }

        public TabHistorico Detalhes(int idHistorico)
        {
            return db.TabHistorico.Where(model => model.idHistorico == idHistorico).FirstOrDefault();
        }
    }
}