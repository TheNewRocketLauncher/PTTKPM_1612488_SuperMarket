using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_DIENTU
    {
        private string MAMH { get; set; }
        private DateTime TGBH { get; set; }

        //contruction
        public DTO_DIENTU()
        {

        }
        public DTO_DIENTU(string mamh, DateTime tgbh)
        {
            this.MAMH = mamh;
            this.TGBH = tgbh;
        }
    }
}
