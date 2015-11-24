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
            //Pesquisa no banco os exemplares que possuem o título informado e que estejam disponíveis
            var exemplares = db.TabExemplar.Where(model => model.TabTitulo.nmTitulo.ToLower() == titulo.ToLower() && model.dsStatus.Equals((int)StatusRegistroExemplar.DISPONIVEL));
            return exemplares;
        }

        public IQueryable<TabExemplar> ObterPorLeitor(long idLeitor)
        {
            var leitor = db.TabLeitor.Where(model => model.idLeitor == idLeitor).FirstOrDefault();

            var exemplares = from e in leitor.TabHistorico select e.TabExemplar;

            return exemplares.AsQueryable();

            //var leitor2 = from a in db.TabLeitor where a.idLeitor == idLeitor select a;


        }
        public Tuple<TabExemplar, bool> ObterPorid(long idExemplar)
        {
            var exemplar = db.TabExemplar.Where(model => model.idExemplar == idExemplar).FirstOrDefault();
            var historico = exemplar.TabHistorico.Where(model => model.fkIdExemplar == idExemplar).LastOrDefault();

            if (historico.dsStatus == (int)EnumStatusHistorico.PENDENTE)
                return new Tuple<TabExemplar, bool>(exemplar, false);

            else
                return new Tuple<TabExemplar, bool>(exemplar, true);
        }

        public string Romper(long idExemplar, string texto)
        {
            //  Recupera o registro que eu quero atualizar e guarda em uma variável do tipo TabExemplar
            TabExemplar e = db.TabExemplar.First(model => model.idExemplar == idExemplar);
            // Atualiza os campos, colocando o nome da variavel que recebeu o registro seguido de "." e o nome do campo.
            e.dsStatus = (int)StatusRegistroExemplar.INATIVO;
            e.dsObs = texto;
            // Salvando as alterações
            db.SaveChanges();
            return "Corrente Rompida! :'(";
        }
    }
}
