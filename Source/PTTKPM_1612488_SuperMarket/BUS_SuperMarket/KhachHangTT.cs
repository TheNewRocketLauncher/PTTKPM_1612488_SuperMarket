using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class KhachHangTT
    {
        public KHTT GetKHTT(KHTT khtt)
        {
            KHTT result;

            var pd = new Product();
            result = pd.getKhtt(khtt);

            return result;
        }

        public Result ThemKHTT(KHTT khtt)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.themKHTT(khtt);

            return result;
        }

        public Result XoaKHTT(KHTT khtt)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.xoaKHTT(khtt);

            return result;
        }

        public Result SuaKHTT(KHTT khtt)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.suaKHTT(khtt);

            return result;
        }
    }
}
