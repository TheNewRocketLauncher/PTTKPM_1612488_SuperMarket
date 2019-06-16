using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_QUANLY
    {
        private int STT { get; set; }
        private int IDUSER { get; set; }
        
        //Contruction//
        public DTO_QUANLY()
        {

        }

        public DTO_QUANLY(int stt, int id)
        {
            this.STT = stt;
            this.IDUSER = id;
        }

    }
}
