using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class SalaChatBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        public IQueryable<TabSalaChat> ObterContatos(long idLeitor)
        {
            var contatos = db.TabSalaChat.Where(model => model.fkIdLeitor == idLeitor || model.fkIdLeitor2 == idLeitor);
            return contatos;
        }

        public Tuple<TabSalaChat, string, bool> Criar(string login, long idLeitor)
        {
            var leitor = db.TabLeitor.Where(model => model.idLeitor == idLeitor).FirstOrDefault();
            var leitor2 = db.TabLeitor.Where(model => model.dsLogin == login).FirstOrDefault();

            if (leitor2 == null)
            {
                return new Tuple<TabSalaChat, string, bool>(null, "Login inexistente", false);
            }

            if (login == leitor.dsLogin)
            {
                return new Tuple<TabSalaChat, string, bool>(null, "O leitor está utilizando seu próprio login", false);
            }

            TabSalaChat objSalaChat = new TabSalaChat
            {
                fkIdLeitor = (int)idLeitor,
                fkIdLeitor2 = leitor2.idLeitor
            };

            db.TabSalaChat.Add(objSalaChat);
            db.SaveChanges();

            string mensagem = "Contato adicionado com sucesso";

            return new Tuple<TabSalaChat, string, bool>(objSalaChat, mensagem, true);

        }
    }
}
