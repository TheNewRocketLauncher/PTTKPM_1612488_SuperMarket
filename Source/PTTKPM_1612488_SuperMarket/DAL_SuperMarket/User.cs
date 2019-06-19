using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PublicClass;

namespace DAL_SuperMarket
{
    public class User
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="TenDangNhap"></param>
        /// <param name="MatKhau"></param>
        /// <returns></returns>
        public Result dangNhap(string TenDangNhap, string MatKhau)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u1 = db.USER_ACCOUNT.FirstOrDefault(b => b.TENDANGNHAP == TenDangNhap);
            if (u1 != null)
            {
                if(u1.MATKHAU.ToString() == MatKhau)
                {
                    result._is_Success = true;
                    result._result = u1.IDUSER;
                }
                else
                {
                    result._is_Success = false;
                    result._error = "Sai mật khẩu";
                }
            }
            else
            {
                result._is_Success = false;
                result._error = "Sai tên đăng nhập";
            }

            return result;
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public Result dangXuat(string idUser)
        {
            var result = new Result(false, "", "");

            try
            {
                var db = new NEWDAY_MARKETEntities();
                var u = db.USER_ACCOUNT.SingleOrDefault(b => b.IDUSER.ToString() == idUser);
                u.IS_USING = false;
                db.SaveChanges();
                result._is_Success = true;
            }
            catch
            {
                result._is_Success = false;
                result._error = "Không thể đăng xuất";
            }

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
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u1 = db.USER_ACCOUNT.FirstOrDefault(b => b.TENDANGNHAP == tenDangNhap);
            if (u1 != null)
            {
                var newacc = new USER_ACCOUNT();
                newacc.TENDANGNHAP = tenDangNhap;
                newacc.MATKHAU = matKhau;
                newacc.USER_TYPE = usertype;
                db.USER_ACCOUNT.Add(newacc);
                db.SaveChanges();
                result._is_Success = true;
                result._result = "Tạo tài khoảng thành công";
            }
            else
            {
                result._is_Success = false;
                result._error = "Tên đăng nhập đã tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Kiểm tra quyền tài khoản
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public Result isQuanLy(int idUser)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u1 = db.USER_ACCOUNT.FirstOrDefault(b => b.IDUSER == idUser);
            bool isQuanly = u1.USER_TYPE.HasValue ? u1.USER_TYPE.Value : false;

            if (isQuanly)
            {
                result._is_Success = true;
                result._result = u1.USER_TYPE.ToString();
            }
            else
            {
                result._is_Success = false;
                result._error = "Lỗi không xác định";
            }

            return result;
        }
    }
}
