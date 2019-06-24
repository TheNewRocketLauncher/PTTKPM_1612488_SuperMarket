using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class HoaDon
    {
        public HOADON GetHoaDonThemMa(int mahd)
        {
            HOADON result;

            var pd = new Product();
            result = pd.getHoaDonTheoMa(mahd);

            return result;
        }

        public HOADON GetHoaDonThemNgay(DateTime date1, DateTime date2)
        {
            HOADON result;

            var pd = new Product();
            result = pd.getHoaDonTheoNgay(date1, date2);

            return result;
        }

        public List<HOADON> GetAllHoaDon()
        {
            List<HOADON> result;

            var pd = new Product();
            result = pd.getAllHoaDon();

            return result;
        }

        public Result ThemHoaDon(HOADON hd)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.themHoaDon(hd);

            return result;
        }
        public Result XoaHoaDon(int mahd)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.xoaHoaDon(mahd);

            return result;
        }

        public Result SuaHoaDon(HOADON hd)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.suaHoaDon(hd);

            return result;
        }
    }
}
