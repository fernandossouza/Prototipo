//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CumminsPrototipo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROTOTIPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROTOTIPO()
        {
            this.PROTOTIPO_GRUPO_EMAIL = new HashSet<PROTOTIPO_GRUPO_EMAIL>();
        }
    
        public long prototipoId { get; set; }
        public string shopOrder { get; set; }
        public string tipo { get; set; }
        public bool status { get; set; }
        public string email { get; set; }
        public int alertLineSet { get; set; }
        public string statusPrototipo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROTOTIPO_GRUPO_EMAIL> PROTOTIPO_GRUPO_EMAIL { get; set; }
    }
}
