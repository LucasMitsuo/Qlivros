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
    
    public partial class TabLog
    {
        public int idLog { get; set; }
        public System.DateTime dtLog { get; set; }
        public int fkIdLeitor { get; set; }
    
        public virtual TabLeitor TabLeitor { get; set; }
    }
}
