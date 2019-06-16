using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_MATHANG
    {
        private string MAMH { get; set; }
        private string TENMATHANG { get; set; }
        private string MASP { get; set; }

        //contruction
        public DTO_MATHANG()
        {

        }

        public DTO_MATHANG(string mamh, string tenmh, string masp)
        {
            this.MAMH = mamh;
            this.TENMATHANG = tenmh;
            this.MASP = masp;
        }
    }
}
