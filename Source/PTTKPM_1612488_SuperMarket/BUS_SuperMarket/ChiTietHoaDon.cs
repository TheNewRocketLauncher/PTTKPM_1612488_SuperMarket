using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class ChiTietHoaDon
    {
        public List<CHITIETHOADON> GetChiTietHoaDon(int mahd)
        {
            List<CHITIETHOADON> result;

            var pd = new Product();
            result = pd.getChiTietHoaDon(mahd);

            return result;
        }

        public Result ThemChiTietHoaDon(CHITIETHOADON cthd)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.themChiTietHoaDon(cthd);

            return result;
        }

        public Result XoaChiTietHoaDonTheoMaHD(int mahd)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.xoaChiTietHoaDonTheoMAHD(mahd);

            return result;
        }

        public Result XoaChiTietHoaDonTheoSTT(int stt)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.xoaChiTietHoaDonTheoSTT(stt);

            return result;
        }

        public Result SuaChiTietHoaDon(CHITIETHOADON cthd)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.suaChiTietHoaDon(cthd);

            return result;
        }
    }
}
