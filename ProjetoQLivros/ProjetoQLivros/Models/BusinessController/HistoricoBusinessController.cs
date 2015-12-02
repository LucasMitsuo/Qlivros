using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class HistoricoBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();

        public Tuple<List<TabHistorico>, bool,TabLeitor> VerificaPropriedade(long idLeitor)
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
                var doado = db.TabHistorico.Where(model=> model.fkIdExemplar == recebido.fkIdExemplar && model.dsStatus.Equals((int)EnumStatusHistorico.DOADO) && model.idHistorico > recebido.idHistorico);

                //se não foi, adiciona em historicos
                if (doado.Count() == 0)
                {
                    historicos.Add(recebido);
                }
            }

            historicos = historicos.Where(model => model.TabExemplar.dsStatus.Equals((int)StatusRegistroExemplar.DISPONIVEL)).ToList();

            //Se não for adicionado nenhum registro a historicos, quer dizer que ele não é proprietário atual de nenhum exemplar
            if (historicos.Count() == 0)
            {
                return new Tuple<List<TabHistorico>, bool,TabLeitor>(null, false,leitor);
            }
            else
            {
                return new Tuple<List<TabHistorico>, bool,TabLeitor>(historicos, true,leitor);
            }
        }

        public IQueryable<TabHistorico> ObterLidos(long idLeitor)
        {
            var historicos = db.TabHistorico.Where(model => model.fkIdLeitor == idLeitor && (model.dsStatus == (int)EnumStatusHistorico.CADASTRADO || model.dsStatus == (int)EnumStatusHistorico.DOADO));
            return historicos;

        }

        public IQueryable<TabHistorico> ListaHistorico(long idExemplar)
        {
            var historicos = db.TabHistorico.Where(model => model.fkIdExemplar == idExemplar && (model.dsStatus == (int)EnumStatusHistorico.CADASTRADO || model.dsStatus == (int)EnumStatusHistorico.DOADO));
            return historicos;
        }

        public string VerificaResposta(int idReceptor,int idDoador, int idExemplar, string resposta)
        {
            TabHistorico resultado = new TabHistorico();
            if (resposta.Equals("aceito"))
            {
                //registra a aceitação
                resultado.fkIdLeitor = idDoador;
                resultado.fkIdExemplar = idExemplar;
                resultado.fkIdReceptor = idReceptor;
                resultado.dsStatus = (int)EnumStatusHistorico.ACEITO;
                resultado.dtHistorico = DateTime.Now;
                db.SaveChanges();

                //registra a doação
                TabHistorico historico = new TabHistorico();
                historico.fkIdLeitor = idReceptor;
                historico.fkIdExemplar = idExemplar;
                historico.dsStatus = (int)EnumStatusHistorico.DOADO;
                historico.dtHistorico = DateTime.Now;
                db.SaveChanges();
            }
            else
            {
                var exemplar = db.TabExemplar.Where(model => model.idExemplar == idExemplar).FirstOrDefault();
                //altera o status para disponível
                exemplar.dsStatus = (int)StatusRegistroExemplar.DISPONIVEL;

                //registra a aceitação
                resultado.fkIdLeitor = idDoador;
                resultado.fkIdExemplar = idExemplar;
                resultado.fkIdReceptor = idReceptor;
                resultado.dsStatus = (int)EnumStatusHistorico.RECUSADO;
                resultado.dtHistorico = DateTime.Now;
                db.SaveChanges();
            }

            return "Uma notificação foi enviada ao Doador";
        }

        public List<TabHistorico> RankingExemplares()
        {
            List<TabHistorico> exRank = new List<TabHistorico>();

            var teste = (from p in db.TabHistorico
                         where p.dsStatus == 5
                         group p by p.fkIdExemplar into g
                         select new { fkIdExemplar = g.Key, Quantidade = g.Count() }
                        ).OrderByDescending(c => c.Quantidade);
            var count = 1;
            foreach (var registro in teste)
            {
                TabHistorico exemplar = new TabHistorico();
                TabExemplar tbex = new TabExemplar();
                TabTitulo tbTit = new TabTitulo();
                tbex = db.TabExemplar.Where(model => model.idExemplar == registro.fkIdExemplar).FirstOrDefault();
                tbTit = db.TabTitulo.Where(model => model.idTitulo == tbex.fkIdTitulo).FirstOrDefault();

                tbex.TabTitulo = tbTit;
                exemplar.idHistorico = count;
                count++;
                exemplar.fkIdExemplar = registro.fkIdExemplar;
                exemplar.dsStatus = registro.Quantidade;
                exemplar.TabExemplar = tbex;
                exRank.Add(exemplar);
            }
            return exRank;
        }

        public List<TabHistorico> RankingLeitores()
        {
            List<TabHistorico> ltrRank = new List<TabHistorico>();

            var teste = (from p in db.TabHistorico
                         where p.dsStatus == 5
                         group p by p.fkIdLeitor into g
                         select new { fkIdLeitor = g.Key, Quantidade = g.Count() }
                        ).OrderByDescending(c => c.Quantidade);
            var count = 1;
            foreach (var registro in teste)
            {
                TabHistorico exemplar = new TabHistorico();

                TabLeitor tbleitor = new TabLeitor();
                tbleitor = db.TabLeitor.Where(model => model.idLeitor == registro.fkIdLeitor).FirstOrDefault();

                exemplar.idHistorico = count;
                count++;
                exemplar.fkIdLeitor = registro.fkIdLeitor;
                exemplar.dsStatus = registro.Quantidade;
                exemplar.TabLeitor = tbleitor;
                ltrRank.Add(exemplar);
            }
            return ltrRank;
        }


        internal object RankingRegioes()
        {
            throw new NotImplementedException();
        }
    }
}
