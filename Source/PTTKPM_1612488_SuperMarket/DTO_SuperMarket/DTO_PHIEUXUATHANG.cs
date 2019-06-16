using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_PHIEUXUATHANG
    {
        private int STT { get; set; }
        private string MASP { get; set; }
        private int SL { get; set; }

        //contruction
        public DTO_PHIEUXUATHANG()
        {

        }
        public DTO_PHIEUXUATHANG(int stt, string masp, int sl)
        {
            this.STT = stt;
            this.MASP = masp;
            this.SL = sl;

        }
    }
}
