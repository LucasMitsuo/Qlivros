using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.TabModels
{
    [MetadataType(typeof(TabLeitorMetadata))]
    public partial class TabLeitor
    {
    
    }

    public class TabLeitorMetadata
    {
        public int idLeitor { get; set; }
        public string dsEmail { get; set; }

        [Required]
        [Display(Name="Login")]
        public string dsLogin { get; set; }

        [Required]
        [Display(Name="Senha")]
        public string dsSenha { get; set; }
        public string nmLeitor { get; set; }
        public string dsSexo { get; set; }
        public string dtNasc { get; set; }
        public string numCel { get; set; }
        public string dsRgLeitor { get; set; }
        public int noEnd { get; set; }
        public string dsComplementoEnd { get; set; }
        public string dsReferenciaEnd { get; set; }
        public string imFoto { get; set; }
        public int fkIdCepEnd { get; set; }
        public int dsStatus { get; set; }
    }

    public enum EnumSexoLeitor
    {
        MASCULINO = 1,
        FEMININO
    }

    public enum EnumStatusLeitor
    {
        ATIVO = 1,
        INATIVO
    }
}
