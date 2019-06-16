using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SuperMarket
{
    class DTO_NHANVIEN
    {
        private int IDUSER { get; set; }
        private string HOTEN { get; set; }
        private bool PHAI { get; set; }
        private string DIACHI { get; set; }
        private string SDT { get; set; }
        private string NGAYSINH { get; set; }
        private string EMAIL { get; set; }
        private bool ISENABLED { get; set; }

        /* === Constructor === */
        public DTO_NHANVIEN()
        {

        }

        public DTO_NHANVIEN(int id, string ht, bool phai, string diachi, string sdt, string ngaysinh, string email, bool isenable)
        {
            this.IDUSER = id;
            this.HOTEN = ht;
            this.PHAI = phai;
            this.DIACHI = diachi;
            this.SDT = sdt;
            this.NGAYSINH = ngaysinh;
            this.EMAIL = email;
            this.ISENABLED = isenable;
        }
    }
}
