//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoQLivros.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TabExemplar
    {
        public TabExemplar()
        {
            this.TabHistorico = new HashSet<TabHistorico>();
            this.TabResenha = new HashSet<TabResenha>();
        }
    
        public int idExemplar { get; set; }
        public string nmEditora { get; set; }
        public string nmAutor { get; set; }
        public string dsEdicao { get; set; }
        public int fkIdTitulo { get; set; }
        public int dsStatus { get; set; }
        public string dsObs { get; set; }
    
        public virtual TabTitulo TabTitulo { get; set; }
        public virtual ICollection<TabHistorico> TabHistorico { get; set; }
        public virtual ICollection<TabResenha> TabResenha { get; set; }
    }
}
