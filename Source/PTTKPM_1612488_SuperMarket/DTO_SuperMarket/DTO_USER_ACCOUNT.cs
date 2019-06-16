using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_USER_ACCOUNT
    {

        private int IDUSER { get; set; }
        private string TENDANGNHAP { get; set; }
        private string MATKHAU { get; set; }
        private bool USER_TYPE { get; set; }
        private bool IS_USING { get; set; }

        //Contruction//
        public DTO_USER_ACCOUNT()
        {

        }

        public DTO_USER_ACCOUNT(int id, string ten, string mk, bool utype, bool is_use)
        {
            this.IDUSER = id;
            this.TENDANGNHAP = ten;
            this.MATKHAU = mk;
            this.USER_TYPE = utype;
            this.IS_USING = is_use;

        }
    }
}
