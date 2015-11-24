using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.TabModels
{
    [MetadataType(typeof(TabHistoricoMetadata))]
    public partial class TabHistorico
    {
       
    }

    public class TabHistoricoMetadata
    {

    }

    public enum EnumStatusHistorico
    {
        CADASTRADO = 1,
        PENDENTE,
        ACEITO,
        RECUSADO,
        DOADO
    }
}
