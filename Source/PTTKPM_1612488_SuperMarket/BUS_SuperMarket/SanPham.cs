using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class SanPham
    {
        public Result ThemSanPham(SANPHAM sp)
        {
            Result result;
            var pd = new Product();
            result = pd.themSanPham(sp);
            return result;
        }

        public Result XoaSanPham(string masp)
        {
            Result result = new Result(false,"","");

            var pd = new Product();
            if(pd.getSanPhamTheoMa(masp) == null)
            {
                result._result = "Không tìm thấy sản phẩm";
                result._error = "Không tìm thấy sản phẩm";
            }
            else
            {
                result = pd.xoaSanPham(masp);
            }
            return result;
        }

        public Result SuaSanPham(SANPHAM sp)
        {
            Result result = new Result(false, "", "");

            var pd = new Product();
            if (pd.getSanPhamTheoMa(sp.MASP) == null)
            {
                result._result = "Không tìm thấy sản phẩm";
                result._error = "Không tìm thấy sản phẩm";
            }
            else
            {
                result = pd.suaSanPham(sp);
            }
            return result;
        }
        public List<SANPHAM> GetSANPHAM(string tenSanPham)
        {
            List<SANPHAM> result;

            var pd = new Product();
            result = pd.getSanPhamTheoTen(tenSanPham);

            return result;
        }

        public List<SANPHAM> GetAllSANPHAM()
        {
            List<SANPHAM> result;

            var pd = new Product();
            result = pd.getAllSanPham();

            return result;
        }

        public SANPHAM GetSANPHAMTheoMASP(string masp)
        {
            SANPHAM result;

            var pd = new Product();
            result = pd.getSanPhamTheoMASP(masp);

            return result;
        }

        public List<SANPHAM> getDanhSachSP()
        {
            List<SANPHAM> result  = new List<SANPHAM>();

            var pd = new Product();
            result = pd.getDanhSachSP();

            return result;
        }

    }
}
