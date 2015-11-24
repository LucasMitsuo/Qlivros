using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoQLivros.Models.TabModels;

namespace ProjetoQLivros.Models.BusinessController
{
    public class HistoricoBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();

        public Tuple<List<TabHistorico>, bool> VerificaPropriedade(long idLeitor)
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

            //Pega todos os exemplares que o leitor recebeu como doação
            var recebidos = db.TabHistorico.Where(model => model.fkIdLeitor == idLeitor && model.dsStatus.Equals((int)EnumStatusHistorico.DOADO));
            foreach (var recebido in recebidos)
            {
                //adiciona esses registros a variável historicos
                historicos.Add(recebido);
            }

            historicos = historicos.Where(model => model.TabExemplar.dsStatus.Equals((int)EnumStatusRegistroExemplar.ATIVO)).ToList();

            //Se não for adicionado nenhum registro a historicos, quer dizer que ele não é proprietário atual de nenhum exemplar
            if (historicos == null)
            {
                return new Tuple<List<TabHistorico>, bool>(null, false);
            }
            else
            {
                return new Tuple<List<TabHistorico>, bool>(historicos, true);
            }
        }
    }
}
