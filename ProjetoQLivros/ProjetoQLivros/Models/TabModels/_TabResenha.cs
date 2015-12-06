using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.TabModels
{
    [MetadataType(typeof(TabResenhaMetadata))]
    public partial class TabResenha
    {
        public string ResolveTipoResenha()
        {
            if (this.dsTipoResenha.Equals(EnumTipoResenha.CONTEUDO))
            {
                return "Conteúdo";
            }
            return "Estado de uso";
        }
    }

    public class TabResenhaMetadata
    {

    }

    public enum EnumTipoResenha
    {
        CONTEUDO = 1,
        ESTADO_DE_USO
    }
}
