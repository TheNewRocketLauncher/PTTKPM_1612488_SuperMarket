using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_SANPHAM
    {
        private string MASP { get; set; }
        private string TENSP { get; set; }
        private DateTime NSX { get; set; }
        private string THUONGHIEU { get; set; }
        private decimal GIATIEN { get; set; }
        private decimal SLTONKHO { get; set; }
        private decimal SLBB { get; set; }
        private string TINHTRANG { get; set; }

        //contruction
        public DTO_SANPHAM()
        {

        }

        public DTO_SANPHAM(string masp, string ten, DateTime nsx, string th, decimal giatien, decimal sltonkho, decimal slbb, string tinhtrang)
        {
            this.MASP = masp;
            this.TENSP = ten;
            this.NSX = nsx;
            this.THUONGHIEU = th;
            this.GIATIEN = giatien;
            this.SLTONKHO = sltonkho;
            this.SLBB = slbb;
            this.TINHTRANG = tinhtrang;
        }
    }
}
