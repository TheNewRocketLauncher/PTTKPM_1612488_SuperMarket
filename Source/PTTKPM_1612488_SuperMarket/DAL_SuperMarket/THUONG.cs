//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_SuperMarket
{
    using System;
    using System.Collections.Generic;
    
    public partial class THUONG
    {
        public int STT { get; set; }
        public int IDUSER { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
