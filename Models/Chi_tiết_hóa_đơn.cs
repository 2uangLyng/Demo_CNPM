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
    
    public partial class Chi_tiết_hóa_đơn
    {
        public int ID_HH { get; set; }
        public int ID_HD { get; set; }
        public int SL { get; set; }
        public int Đơn_giá { get; set; }
        public int Thành_tiền { get; set; }
    
        public virtual Hóa_đơn Hóa_đơn { get; set; }
        public virtual Hàng_Hóa Hàng_Hóa { get; set; }
    }
}
