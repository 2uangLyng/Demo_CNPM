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
    
    public partial class Hàng_Hóa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hàng_Hóa()
        {
            this.Chi_tiết_hóa_đơn = new HashSet<Chi_tiết_hóa_đơn>();
        }
    
        public int ID { get; set; }
        public string Tên { get; set; }
        public int Số_Lượng { get; set; }
        public int Giá_mua { get; set; }
        public int Giá_bán { get; set; }
        public string ID_loại { get; set; }
        public string ID_DVT { get; set; }
        public Nullable<int> SL_ton { get; set; }
        public string Hinh_anh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chi_tiết_hóa_đơn> Chi_tiết_hóa_đơn { get; set; }
        public virtual ĐVT ĐVT { get; set; }
        public virtual Loại Loại { get; set; }
    }
}
