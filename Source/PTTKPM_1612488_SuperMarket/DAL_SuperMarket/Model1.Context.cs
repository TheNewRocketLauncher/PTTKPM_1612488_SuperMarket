﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NEWDAY_MARKETEntities : DbContext
    {
        public NEWDAY_MARKETEntities()
            : base("name=NEWDAY_MARKETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }


        public virtual DbSet<CHIETKHAU> CHIETKHAU { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADON { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<KHTT> KHTT { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAM { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHIEUNHAPHANG> PHIEUNHAPHANG { get; set; }
        public virtual DbSet<PHIEUXUATHANG> PHIEUXUATHANG { get; set; }
        public virtual DbSet<QUANLY> QUANLY { get; set; }
        public virtual DbSet<SANPHAM> SANPHAM { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<THUONG> THUONG { get; set; }
        public virtual DbSet<USER_ACCOUNT> USER_ACCOUNT { get; set; }
    }
}