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
    
    public partial class CHITIETHOADON
    {
        public int STT { get; set; }
        public Nullable<int> MAHD { get; set; }
        public string MASP { get; set; }
        public int SL { get; set; }
        public Nullable<decimal> DONGIA { get; set; }
        public Nullable<float> CHIETKHAU { get; set; }
        public Nullable<int> MAKHTT { get; set; }
        public Nullable<decimal> THANHTIEN { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual KHTT KHTT { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}