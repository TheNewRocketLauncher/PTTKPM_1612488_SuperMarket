using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class ChieKhau
    {
        public List<CHIETKHAU> GetChietKhau(string masp, DateTime date)
        {
            List<CHIETKHAU> result;

            var pd = new Product();
            result = pd.getChietKhau(masp, date);

            return result;
        }

        public Result ThemChietKhau(CHIETKHAU ck)
        {
            Result result = new Result(false, "", "");

            var pd = new Product();
            result = pd.themChietKhau(ck);

            return result;
        }

        public Result XoaChietKhau(string masp, DateTime thoigiankt)
        {
            Result result = new Result(false, "", "");

            var pd = new Product();
            result = pd.xoaChietKhau(masp, thoigiankt);

            return result;
        }

        public Result SuaChietKhau(CHIETKHAU ck)
        {
            Result result = new Result(false, "", "");

            var pd = new Product();
            result = pd.suaChietKhau(ck);

            return result;
        }
    }
}
