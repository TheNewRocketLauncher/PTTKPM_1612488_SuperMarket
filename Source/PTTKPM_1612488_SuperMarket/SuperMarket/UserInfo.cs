using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public class UserInfo
    {
        public string _TenDangNhap { get; set; }
        public string _MatKhau { get; set; }
        public int _IDUser { get; set; }

        public UserInfo()
        {
            _TenDangNhap = "";
            _MatKhau = "";
            _IDUser = 0;
        }

        public UserInfo(string tendangnhap, string matkhau, int iduser)
        {
            _TenDangNhap = tendangnhap;
            _MatKhau = matkhau;
            _IDUser = iduser;
        }
    }
}
