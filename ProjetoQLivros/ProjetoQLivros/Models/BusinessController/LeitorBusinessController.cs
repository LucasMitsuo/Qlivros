using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.BusinessController
{
    public class LeitorBusinessController
    {
        QLivrosEntities db = new QLivrosEntities();
        LogradouroBusinessController enderecoBC = new LogradouroBusinessController();
        public Tuple<TabLeitor,bool> VerificaLogin(TabLeitor dadosLeitor)
        {
            var leitor = db.TabLeitor.Where(model => model.dsLogin == dadosLeitor.dsLogin && model.dsSenha == dadosLeitor.dsSenha).FirstOrDefault();
            if (leitor == null)
            {
                return new Tuple<TabLeitor,bool>(null,false);
            }
            else
            {
                return new Tuple<TabLeitor, bool>(leitor, true);
            }
        }

        public TabLeitor Obter(long idLeitor)
        {
            var leitor = db.TabLeitor.Where(model => model.idLeitor == idLeitor).FirstOrDefault();
            return leitor;
        }

        public TabLeitor CadastrarLeitor(TabLeitor leitor, string rua, string bairro, string cidade, string estado)
        {
            var endereco = enderecoBC.CriarEndereco(rua, bairro, cidade, estado);
            //returando as máscaras dos campos de celular e RG
            leitor.numCel = leitor.numCel.Replace("(","");
            leitor.numCel = leitor.numCel.Replace(")", "");
            leitor.numCel = leitor.numCel.Replace("-", "");
            leitor.numCel = leitor.numCel.Replace(" ", "");
            leitor.dsRgLeitor = leitor.dsRgLeitor.Replace("-", "");
            leitor.fkIdCepEnd = endereco.idCepEnd;
            leitor.dsStatus = (int)EnumStatusLeitor.ATIVO;
            db.TabLeitor.Add(leitor);
            db.SaveChanges();
            return leitor;
        }
    }
}
