//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedEmpeloOffLine.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Departamento
    {
        public Departamento()
        {
            this.Municipio = new HashSet<Municipio>();
        }
    
        public string IdCodigo { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
