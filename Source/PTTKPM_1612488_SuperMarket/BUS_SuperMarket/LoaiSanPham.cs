using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SuperMarket;
using PublicClass;

namespace BUS_SuperMarket
{
    public class LoaiSanPham
    {
        public List<LOAISANPHAM> GetAllLoaiSanPham()
        {
            List<LOAISANPHAM> result;

            var pd = new Product();
            result = pd.getAllLoaiSanPham();

            return result;
        }

        public int GetMaLoaiSanPham(string tenloai)
        {
            int result;

            var pd = new Product();
            result = pd.getMaLoaiSanPham(tenloai);

            return result;
        }

        public Result ThemLoaiSanPham(LOAISANPHAM lsp)
        {
            Result result = new Result(false, "", "");

            var pd = new Product();
            result = pd.themLoaiSanPham(lsp);

            return result;
        }

        public Result XoaLoaiSanPham(string malsp)
        {
            Result result = new Result(false, "", "");

            var pd = new Product();
            result = pd.xoaLoaiSanPham(malsp);

            return result;
        }

        public Result SuaLoaiSanPham(LOAISANPHAM lsp)
        {
            Result result = new Result(false, "", "");

            var pd = new Product();
            result = pd.suaLoaiSanPham(lsp);

            return result;
        }
    }
}
