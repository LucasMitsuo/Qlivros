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
    
    public partial class TabResenha
    {
        public int idResenha { get; set; }
        public string dsResenha { get; set; }
        public string dsTipoResenha { get; set; }
        public int fkIdLeitor { get; set; }
        public int fkIdExemplar { get; set; }
    
        public virtual TabExemplar TabExemplar { get; set; }
        public virtual TabLeitor TabLeitor { get; set; }
    }
}
