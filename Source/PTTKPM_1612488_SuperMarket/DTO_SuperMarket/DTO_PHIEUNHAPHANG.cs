using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_PHIEUNHAPHANG
    {
        private int STT { get; set; }
        private string MASP { get; set; }
        private int SL { get; set; }

        //contruction
        public DTO_PHIEUNHAPHANG()
        {

        }
        public DTO_PHIEUNHAPHANG(int stt, string masp, int sl)
        {
            this.STT = stt;
            this.MASP = masp;
            this.SL = sl;

        }
    }
}
