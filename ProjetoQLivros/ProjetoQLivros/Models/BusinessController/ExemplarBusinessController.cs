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

        public List<TabHistorico> FiltrarTitulo(string titulo)
        {
            List<TabHistorico> historicos = new List<TabHistorico>();
            //Pesquisa no banco os exemplares que possuem o título informado e que estejam disponíveis
            var exemplares = db.TabExemplar.Where(model => model.TabTitulo.nmTitulo.ToLower() == titulo.ToLower() && model.dsStatus.Equals((int)StatusRegistroExemplar.DISPONIVEL));

            foreach (var exemplar in exemplares)
            {
                var ultimoRegistro = exemplar.TabHistorico.Where(model => model.fkIdExemplar == exemplar.idExemplar).LastOrDefault();
                if (ultimoRegistro.TabExemplar.dsStatus == (int)StatusRegistroExemplar.DISPONIVEL)
                {
                    historicos.Add(ultimoRegistro);
                }
            }    
            return historicos;
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

        public Tuple<List<TabHistorico>, bool> ObterIndisponiveis(long idLeitor)
        {
            List<TabHistorico> historicos = new List<TabHistorico>();

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
                var doado = db.TabHistorico.Where(model => model.fkIdExemplar == recebido.fkIdExemplar && model.dsStatus.Equals((int)EnumStatusHistorico.DOADO));

                //se não foi, adiciona em historicos
                if (doado.Count() == 0)
                {
                    historicos.Add(recebido);
                }
            }

            historicos = historicos.Where(model => model.TabExemplar.dsStatus.Equals((int)StatusRegistroExemplar.INDISPONIVEL)).ToList();

            //Se não for adicionado nenhum registro a historicos, quer dizer que ele não é proprietário atual de nenhum exemplar
            if (historicos.Count() == 0)
            {
                return new Tuple<List<TabHistorico>, bool>(null, false);
            }
            else
            {
                return new Tuple<List<TabHistorico>, bool>(historicos, true);
            }
        }

        // Esse seria o método ObterPorid de Disponibilizar Exemplar
        public TabExemplar ObterPorIdDisp(long idExemplar)
        {
            var exemplar = db.TabExemplar.Where(model => model.idExemplar == idExemplar).FirstOrDefault();

            return exemplar;

        }

        public string Alterar(long idExemplar)
        {
            //  Recupera o registro que eu quero atualizar e guarda em uma variável do tipo TabExemplar
            TabExemplar e = db.TabExemplar.First(model => model.idExemplar == idExemplar);
            // Atualiza o campo dsEstatus, colocando o nome da variavel que recebeu o registro seguido de "." e o nome do campo.
            e.dsStatus = (int)StatusRegistroExemplar.DISPONIVEL;
            // Salvando as alterações
            db.SaveChanges();
            return String.Format("Exemplar {0} disponível com sucesso !",e.TabTitulo.nmTitulo);
        }

        public Tuple<TabExemplar, string> Criar(TabExemplar exemplar, string titulo,int idLeitor)
        {
            TabExemplar novoExemplar = new TabExemplar();
            TabHistorico novoHistorico = new TabHistorico();

            //Pesquisa no banco se o título informado já existe
            var _titulo = db.TabTitulo.Where(model => model.nmTitulo.ToLower() == titulo.ToLower()).FirstOrDefault();

            //Senão NÃO existir, preenche a TabTitulo e TabExemplar com as informações passada como parâmetro
            if (_titulo == null)
            {
                //Monta o objeto TabTitulo
                TabTitulo novoTitulo = new TabTitulo();
                novoTitulo.nmTitulo = titulo;
                //Adiciona o titulo no contexto do EF
                novoTitulo = db.TabTitulo.Add(novoTitulo);

                //Monta o objeto TabExemplar
                novoExemplar.nmEditora = exemplar.nmEditora;
                novoExemplar.nmAutor = exemplar.nmAutor;
                novoExemplar.dsEdicao = exemplar.dsEdicao;
                novoExemplar.fkIdTitulo = novoTitulo.idTitulo;
                novoExemplar.dsStatus = (int)StatusRegistroExemplar.DISPONIVEL;
                //Adiciona o exemplar no contexto do EF
                novoExemplar = db.TabExemplar.Add(novoExemplar);

                //Monta o objeto historico
                novoHistorico.dtHistorico = DateTime.Now;
                novoHistorico.dsStatus = (int)EnumStatusHistorico.CADASTRADO;
                novoHistorico.fkIdExemplar = novoExemplar.idExemplar;
                novoHistorico.fkIdLeitor = idLeitor;
                novoHistorico.fkIdReceptor = null;
                //Adiciona o historico no contexto do EF
                db.TabHistorico.Add(novoHistorico);

                db.SaveChanges();

            }
            //Mas se JÁ existir, preenche somente a tabela exemplar
            else
            {
                //Monta o objeto TabExemplar
                novoExemplar.nmEditora = exemplar.nmEditora;
                novoExemplar.nmAutor = exemplar.nmAutor;
                novoExemplar.dsEdicao = exemplar.dsEdicao;
                novoExemplar.fkIdTitulo = _titulo.idTitulo;
                novoExemplar.dsStatus = (int)StatusRegistroExemplar.DISPONIVEL;
                //Persiste o exemplar
                novoExemplar = db.TabExemplar.Add(novoExemplar);

                //Monta o objeto historico
                novoHistorico.dtHistorico = DateTime.Now;
                novoHistorico.dsStatus = (int)EnumStatusHistorico.CADASTRADO;
                novoHistorico.fkIdExemplar = novoExemplar.idExemplar;
                novoHistorico.fkIdLeitor = idLeitor;
                novoHistorico.fkIdReceptor = null;
                 //Adiciona o historico no contexto do EF
                db.TabHistorico.Add(novoHistorico);

                db.SaveChanges();
            }

            return new Tuple<TabExemplar, string>(novoExemplar, "Exemplar cadastrado com sucesso");
        }
    }
}
