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
    
    public partial class USER_ACCOUNT
    {
        public Nullable<int> IDUSER { get; set; }
        public string TENDANGNHAP { get; set; }
        public string MATKHAU { get; set; }
        public Nullable<bool> USER_TYPE { get; set; }
        public Nullable<bool> IS_USING { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
