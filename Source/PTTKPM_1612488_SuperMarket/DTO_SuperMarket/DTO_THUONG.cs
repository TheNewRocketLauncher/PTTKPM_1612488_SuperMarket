using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_THUONG
    {
        private int STT { get; set; }
        private int IDUSER { get; set; }

        //Contruction//
        public DTO_THUONG()
        {

        }

        public DTO_THUONG(int stt, int id)
        {
            this.STT = stt;
            this.IDUSER = id;
        }
    }
}
