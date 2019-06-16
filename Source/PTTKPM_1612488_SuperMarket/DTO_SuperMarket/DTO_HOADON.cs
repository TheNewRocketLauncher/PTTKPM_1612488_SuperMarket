using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_HOADON
    {
        private int STT { get; set; }
        private int MAHD { get; set; }
        private DateTime NGAYTT { get; set; }
        private string MASP { get; set; }
        private int SL { get; set; }
        private decimal DONGIA { get; set; }
        private decimal CHIETKHAU { get; set; }
        private string MAKHTT { get; set; }
        private decimal THANHTIEN { get; set; }

        //contruction
        public DTO_HOADON()
        {

        }

        public DTO_HOADON(int stt, int mahd, DateTime ngaytt, string masp, int sl, decimal dongia, decimal chietkhau, string makhtt, decimal thanhtien)
        {
            this.STT = stt;
            this.MAHD = mahd;
            this.NGAYTT = ngaytt;
            this.MASP = masp;
            this.SL = sl;
            this.DONGIA = dongia;
            this.CHIETKHAU = chietkhau;
            this.MAKHTT = makhtt;
            this.THANHTIEN = thanhtien;

        }
    }
}
