using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class PhieuNhapHang
    {
        public List<PHIEUNHAPHANG> GetPhieuNhapHang(string masp)
        {
            List<PHIEUNHAPHANG> resutl;

            var pd = new Product();
            resutl = pd.getPhieuNhapHang(masp);

            return resutl;
        }

        public Result ThemPhieuNhapHang(PHIEUNHAPHANG pnh)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.themPhieuNhapHang(pnh);

            return result;
        }

        public Result XoaPhieuNhapHang(PHIEUNHAPHANG pnh)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.themPhieuNhapHang(pnh);

            return result;
        }

        public Result SuaPhieuNhapHang(PHIEUNHAPHANG pnh)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.suaPhieuNhapHang(pnh);

            return result;
        }
    }
}
