//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoQLivros.Models.TabModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class TabTitulo
    {
        public TabTitulo()
        {
            this.TabExemplar = new HashSet<TabExemplar>();
        }
    
        public int idTitulo { get; set; }
        public string nmTitulo { get; set; }
    
        public virtual ICollection<TabExemplar> TabExemplar { get; set; }
    }
}
