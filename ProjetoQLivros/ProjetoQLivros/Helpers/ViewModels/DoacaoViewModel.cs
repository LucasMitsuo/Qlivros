using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjetoQLivros.Helpers.ViewModels
{
    public class DoacaoViewModel
    {
        public ICollection<TabHistorico> Historicos { get; set; }

        public List<SelectListItem> OpcoesExemplares { get; set; }

        public int idDoador { get; set; }
    }
}
