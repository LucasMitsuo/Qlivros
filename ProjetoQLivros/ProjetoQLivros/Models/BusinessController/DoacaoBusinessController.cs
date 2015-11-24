using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class DoacaoBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        public Tuple<bool,string> Doar(string email, string login, int idExemplar, int idDoador)
        {
            var receptor = db.TabLeitor.Where(model => model.dsLogin.ToLower() == login.ToLower() && model.dsEmail.ToLower() == email.ToLower()).FirstOrDefault();
            var doador = db.TabLeitor.Where(model => model.idLeitor == idDoador).FirstOrDefault();
            var exemplar = db.TabExemplar.Where(model => model.idExemplar == idExemplar).FirstOrDefault();

            //Verifica se o leitor digitou um login ou email desconhecidos ou de um leitor que está inativo
            if (receptor == null || receptor.dsStatus == (int)EnumStatusLeitor.INATIVO)
            {
                return new Tuple<bool, string>(false, "Leitor não encontrado");
            }

            if (receptor.dsLogin.Equals(doador.dsLogin) && receptor.dsEmail.Equals(doador.dsEmail))
            {
                return new Tuple<bool, string>(false, "Não é possível doar para si mesmo");
            }

            TabHistorico historico = new TabHistorico()
            {
                fkIdExemplar = idExemplar,
                fkIdLeitor = idDoador,
                fkIdReceptor = receptor.idLeitor,
                dtHistorico = DateTime.Now,
                dsStatus = (int)EnumStatusHistorico.PENDENTE
            };

            exemplar.dsStatus = (int)StatusRegistroExemplar.DISPONIVEL;

            db.TabHistorico.Add(historico);
            db.SaveChanges();

            return new Tuple<bool, string>(true, "Notificação enviada com sucesso");
        }
    }
}
