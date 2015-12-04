using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.TabModels
{
    [MetadataType(typeof(TabTituloMetadata))]
    public partial class TabTitulo
    {

    }

    public class TabTituloMetadata
    {
        public int idTitulo { get; set; }

        [Required(ErrorMessage="O título é obrigatório")]
        public string nmTitulo { get; set; }
    }
}
