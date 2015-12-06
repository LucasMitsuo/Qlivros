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
            resenha.dtPublicacao = DateTime.Now;
            db.TabResenha.Add(resenha);
            db.SaveChanges();
        }

        public Tuple<List<TabHistorico>, bool, TabLeitor> VerificaPropriedade(long idLeitor)
        {
            List<TabHistorico> historicos = new List<TabHistorico>();

            var leitor = db.TabLeitor.Where(model => model.idLeitor == idLeitor).FirstOrDefault();

            //Pega todos os registros no qual o leitor cadastrou um exemplar, porém, não é certo que o leitor ainda seja o 
            //proprietário atual desses exemplares
            var cadastrados = db.TabHistorico.Where(model => model.fkIdLeitor == idLeitor && (model.dsStatus == (int)EnumStatusHistorico.CADASTRADO));
            foreach (var registro in cadastrados)
            {
                //pega cada exemplar de cadastrados e verifica se ele ja foi doado
                var doacoes = db.TabHistorico.Where(model => model.fkIdExemplar == registro.fkIdExemplar && model.dsStatus.Equals((int)EnumStatusHistorico.DOADO));

                //se doacoes vier menor que 0, quer dizer que o exemplar nunca foi doado, logo, o leitor é proprietário atual desse exemplar
                if (doacoes.Count() == 0)
                {
                    //então adiciona o registro desse exemplar em HISTORICOS
                    historicos.Add(registro);
                }
            }
            //==========================================
            //Pega todos os exemplares que o leitor recebeu como doação, mas não é certo se ele ainda está com o exemplar doado
            var recebidos = db.TabHistorico.Where(model => model.fkIdLeitor == idLeitor && model.dsStatus.Equals((int)EnumStatusHistorico.DOADO));
            foreach (var recebido in recebidos)
            {
                //Pesquisa se o exemplar recebido como doação já foi doado alguma vez
                var doado = db.TabHistorico.Where(model => model.fkIdExemplar == recebido.fkIdExemplar && model.dsStatus.Equals((int)EnumStatusHistorico.DOADO) && model.idHistorico > recebido.idHistorico);

                //se não foi, adiciona em historicos
                if (doado.Count() == 0)
                {
                    historicos.Add(recebido);
                }
            }

            historicos = historicos.Where(model => model.TabExemplar.dsStatus.Equals((int)StatusRegistroExemplar.DISPONIVEL) || model.TabExemplar.dsStatus.Equals((int)StatusRegistroExemplar.INDISPONIVEL)).ToList();

            //Se não for adicionado nenhum registro a historicos, quer dizer que ele não é proprietário atual de nenhum exemplar
            if (historicos.Count() == 0)
            {
                return new Tuple<List<TabHistorico>, bool, TabLeitor>(null, false, leitor);
            }
            else
            {
                return new Tuple<List<TabHistorico>, bool, TabLeitor>(historicos, true, leitor);
            }
        }
     }
}

