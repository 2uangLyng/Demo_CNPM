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
    
    public partial class PhanQuyen
    {
        public string IdNV { get; set; }
        public int IdChucNang { get; set; }
        public string TenQuyen { get; set; }
    
        public virtual ChucNang ChucNang { get; set; }
        public virtual Nhân_viên Nhân_viên { get; set; }
    }
}
