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
        public List<LOAISANPHAM> GetLoaiSanPham(string tenLoaiSanPham)
        {
            List<LOAISANPHAM> result;

            var pd = new Product();
            result = pd.getLoaiSanPham(tenLoaiSanPham);

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
