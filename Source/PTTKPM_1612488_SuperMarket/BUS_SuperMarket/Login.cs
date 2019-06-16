using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class Login
    {
        /// <summary>
        /// Đăng nhập tài khoản
        /// </summary>
        /// <param name="TenDangNhap"></param>
        /// <param name="MatKhau"></param>
        /// <returns></returns>
        public Result dangNhap(string TenDangNhap, string MatKhau)
        {
            Result result;
            var user = new User();
            result = user.dangNhap(TenDangNhap, MatKhau);
            return result;
        }

        /// <summary>
        /// Đăng xuất tài khoản
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public Result dangXuat(string idUser)
        {
            Result result;
            var user = new User();
            result = user.dangXuat(idUser);
            return result;
        }

        /// <summary>
        /// Tạo tài khoản mới
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <param name="matKhau"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public Result taoTaiKhoan(string tenDangNhap, string matKhau, bool usertype)
        {
            Result result;
            var user = new User();
            result = user.taoTaiKhoan(tenDangNhap, matKhau, usertype);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public Result isQuanLy(int idUser)
        {
            var result = new Result(false, "", "");
            var user = new User();
            result = user.isQuanLy(idUser);
            return result;
        }
    }
}
