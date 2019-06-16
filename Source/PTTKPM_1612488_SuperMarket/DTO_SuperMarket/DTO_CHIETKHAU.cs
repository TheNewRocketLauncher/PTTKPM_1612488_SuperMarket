using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_CHIETKHAU
    {
        private int STT { get; set; }
        private string MASP { get; set; }
        private decimal CK { get; set; }
        private DateTime THOIGIANBD { get; set; }
        private DateTime THOIGIANKT { get; set; }
        private string TENLOAI { get; set; }


        //contruction
        public DTO_CHIETKHAU()
        {

        }
        public DTO_CHIETKHAU(int stt, string masp, decimal ck, DateTime tgbd, DateTime tgkt, string tenloai)
        {
            this.STT = stt;
            this.MASP = masp;
            this.CK = ck;
            this.THOIGIANBD = tgbd;
            this.THOIGIANKT = tgkt;
            this.TENLOAI = tenloai;
        }
    }
}
