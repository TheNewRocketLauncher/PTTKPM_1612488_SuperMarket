using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class PhieuXuatHang
    {
        public List<PHIEUXUATHANG> GetPhieuXuatHang(string masp)
        {
            List<PHIEUXUATHANG> resutl;

            var pd = new Product();
            resutl = pd.getPhieuXuatHang(masp);

            return resutl;
        }

        public List<PHIEUXUATHANG> GetAllPhieuXuatHang()
        {
            List<PHIEUXUATHANG> resutl;

            var pd = new Product();
            resutl = pd.getAllPhieuXuatHang();

            return resutl;
        }
        public Result ThemPhieuXuatHang(PHIEUXUATHANG pxh)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.themPhieuXuatHang(pxh);

            return result;
        }

        public Result XoaPhieuXuatHang(PHIEUXUATHANG pxh)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.themPhieuXuatHang(pxh);

            return result;
        }

        public Result SuaPhieuXuatHang(PHIEUXUATHANG pxh)
        {
            Result result = new Result();

            var pd = new Product();
            result = pd.suaPhieuXuatHang(pxh);

            return result;
        }
    }
}
