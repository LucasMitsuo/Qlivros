using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.Partials
{
    [MetadataType(typeof(TabLeitorMetadata))]
    public partial class TabLeitor
    {
    
    }

    public class TabLeitorMetadata
    {

    }

    public enum EnumSexoLeitor
    {
        MASCULINO = 1,
        FEMININO
    }
}
