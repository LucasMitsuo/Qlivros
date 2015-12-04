using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoQLivros.Models.TabModels
{
    [MetadataType(typeof(TabExemplarMetadata))]
    public partial class TabExemplar
    {
        public bool IsDisponivel()
        {
            if (this.dsStatus.Equals((int)StatusRegistroExemplar.DISPONIVEL))
            {
                return true;
            }
            return false;
        }
    }

    public class TabExemplarMetadata
    {
        public int idExemplar { get; set; }

        [Required(ErrorMessage="A editora é obrigatória")]
        public string nmEditora { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório")]
        public string nmAutor { get; set; }

        [Required(ErrorMessage = "A edição é obrigatória")]
        public string dsEdicao { get; set; }

        public int fkIdTitulo { get; set; }
        public int dsStatus { get; set; }
        public string dsObs { get; set; }
    }

    public enum StatusRegistroExemplar
    {
        DISPONIVEL = 1,
        INDISPONIVEL,
        INATIVO
    }
}
