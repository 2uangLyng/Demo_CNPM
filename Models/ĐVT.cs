//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_CNPM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ĐVT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ĐVT()
        {
            this.Hàng_Hóa = new HashSet<Hàng_Hóa>();
        }
    
        public string ID { get; set; }
        public string Tên { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hàng_Hóa> Hàng_Hóa { get; set; }
    }
}
