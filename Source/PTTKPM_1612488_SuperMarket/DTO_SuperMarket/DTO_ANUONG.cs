using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_ANUONG
    {
        private string MAMH { get; set; }
        private DateTime HSD { get; set; }

        //contruction
        public DTO_ANUONG()
        {

        }
        public DTO_ANUONG(string mamh, DateTime hsd)
        {
            this.MAMH = mamh;
            this.HSD = hsd;
        }
    }
}
