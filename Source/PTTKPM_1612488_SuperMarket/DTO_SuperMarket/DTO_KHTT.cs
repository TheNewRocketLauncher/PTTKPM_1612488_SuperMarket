using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_KHTT
    {
        private string MAKHTT { get; set; }
        private string CMND { get; set; }
        private string SDT { get; set; }
        private int B { get; set; }
        private DateTime THOIHAN { get; set; }
        private decimal TIENTL { get; set; }

        //contruction
        public DTO_KHTT()
        {

        }

        public DTO_KHTT(string makhtt, string cmnd, string sdt, int b, DateTime thoihan, decimal tientl)
        {
            this.MAKHTT = makhtt;
            this.CMND = cmnd;
            this.SDT = sdt;
            this.B = b;
            this.THOIHAN = thoihan;
            this.TIENTL = tientl;
        }
    }
}
