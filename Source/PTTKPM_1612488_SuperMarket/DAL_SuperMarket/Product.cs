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
    /// <summary>
    /// Tất cả các fuction tương tác với sản phẩm
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Lấy sản phẩm
        /// </summary>
        /// <param name="masp"></param>
        /// <returns></returns>
        public SANPHAM getSanPham(string masp)
        {
            SANPHAM result;

            var db = new NEWDAY_MARKETEntities();
            result = db.SANPHAM.FirstOrDefault(b => b.MASP == masp);

            return result;
        }

        /// <summary>
        /// Tìm sản phẩm the mã sản phẩm
        /// </summary>
        /// <param name="masp"></param>
        /// <returns></returns>
        public SANPHAM getSanPhamTheoMa(string masp)
        {
            SANPHAM result;

            var db = new NEWDAY_MARKETEntities();
            result = db.SANPHAM.FirstOrDefault(b => b.MASP == masp);

            return result;
        }

        /// <summary>
        /// Tìm sản phẩm them tên sản phẩm
        /// </summary>
        /// <param name="tenSanPham"></param>
        /// <returns></returns>
        public List<SANPHAM> getSanPhamTheoTen(string tenSanPham)
        {
            List<SANPHAM> result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.SANPHAM.Where(b => b.TENSP == tenSanPham).ToList();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="masp"></param>
        /// <returns></returns>
        public SANPHAM getSanPhamTheoMASP(string masp)
        {
            SANPHAM result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.SANPHAM.FirstOrDefault(b => b.MASP == masp);

            return result;
        }
        
        /// <summary>
        /// Lấy danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<SANPHAM> getAllSanPham()
        {
            List<SANPHAM> result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.SANPHAM.ToList();

            return result;
        }

        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="tensp"></param>
        /// <param name="nsx"></param>
        /// <param name="thuonghieu"></param>
        /// <param name="giatien"></param>
        /// <param name="tinhtrang"></param>
        /// <returns></returns>
        public Result themSanPham(SANPHAM sp)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.SANPHAM.FirstOrDefault(b => b.TENSP == sp.MASP);

            if (u == null)
            {
                try
                {
                    var newsp = new SANPHAM();

                    newsp.MASP = sp.MASP;
                    newsp.TENSP = sp.MASP;
                    newsp.NSX = sp.NSX;
                    newsp.THUONGHIEU = sp.THUONGHIEU;
                    newsp.GIATIEN = sp.GIATIEN;
                    newsp.TINHTRANG = sp.TINHTRANG;
                    newsp.SLBB = sp.SLBB;
                    newsp.SLTONKHO = sp.SLTONKHO;
                    newsp.MALOAI = sp.MALOAI;
                    newsp.THOIHAN = sp.THOIHAN;

                    db.SANPHAM.Add(newsp);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể thêm sản phẩm mới";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Sản phẩm đã tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="masp"></param>
        /// <returns></returns>
        public Result xoaSanPham(string masp)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.SANPHAM.FirstOrDefault(b => b.MASP == masp);
            if (u != null)
            {
                try
                {
                    u.TINHTRANG = "DELETE";
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa sản phẩm";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Sản phẩm không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa thông tin sản phẩm
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public Result suaSanPham(SANPHAM sp)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.SANPHAM.SingleOrDefault(b => b.MASP == sp.MASP);
            if (u != null)
            {
                try
                {
                    u.TENSP = sp.TENSP;
                    u.MALOAI = sp.MALOAI;
                    u.LOAISANPHAM = sp.LOAISANPHAM;
                    u.SLBB = sp.SLBB;
                    u.THOIHAN = sp.THOIHAN;
                    u.THUONGHIEU = sp.THUONGHIEU;
                    u.TINHTRANG = sp.TINHTRANG;
                    u.SLTONKHO = sp.SLTONKHO;
                    
                    db.SaveChangesAsync();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể sửa sản phẩm";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Sản phẩm không tồn tại";
            }

            return result;
        }

        

        /// <summary>
        /// Lấy thông tin chiết khấu
        /// </summary>
        /// <param name="masp"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<CHIETKHAU> getChietKhau(string masp, DateTime date)
        {
            List<CHIETKHAU> result = null;

            var db = new NEWDAY_MARKETEntities();
            var u = db.CHIETKHAU.Where(b => b.MASP == masp && b.THOIGIANKT > date).ToList();
            if (u != null)
            {
                result = u;
            }
            else
            {
                result = null;
            }

            return result;
        }

        public List<CHIETKHAU> getAllChietKhau()
        {
            List<CHIETKHAU> result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.CHIETKHAU.ToList();
            

            return result;
        }
        
        /// <summary>
        /// Thêm chiết khẩu mới
        /// </summary>
        /// <param name="masp"></param>
        /// <param name="ck"></param>
        /// <param name="thoigianbd"></param>
        /// <param name="thoigiankt"></param>
        /// <param name="tenloai"></param>
        /// <returns></returns>
        public Result themChietKhau(CHIETKHAU ck)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();

            try
            {
                var newck = new CHIETKHAU();
                newck.MASP = ck.MASP;
                newck.CK = ck.CK;
                newck.THOIGIANBD = ck.THOIGIANBD;
                newck.THOIGIANKT = ck.THOIGIANKT;
                newck.TENLOAI = ck.TENLOAI;

                db.CHIETKHAU.Add(newck);
                db.SaveChanges();
                result._is_Success = true;
            }
            catch (Exception e)
            {
                result._is_Success = false;
                result._error = e.ToString();
                result._result = "Không thể thêm Chiết khấu";
            }

            return result;
        }

        /// <summary>
        /// Xóa chiết khấu
        /// </summary>
        /// <param name="masp"></param>
        /// <param name="thoigiankt"></param>
        /// <returns></returns>
        public Result xoaChietKhau(string masp, DateTime thoigiankt)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.CHIETKHAU.FirstOrDefault(b => b.MASP == masp && b.THOIGIANKT == thoigiankt);
            if (u != null)
            {
                try
                {
                    db.CHIETKHAU.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa chiết khấu";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Chiết khấu không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa mặt hàng
        /// </summary>
        /// <param name="ck"></param>
        /// <returns></returns>
        public Result suaChietKhau(CHIETKHAU ck)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.CHIETKHAU.FirstOrDefault(b => b.STT == ck.STT);
            if (u != null)
            {
                try
                {
                    u = ck;
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể sửa sản phẩm";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Sản phẩm không tồn tại";
            }

            return result;
        }



        /// <summary>
        /// Thêm loại sản phẩm mới
        /// </summary>
        /// <param name="lsp"></param>
        /// <returns></returns>
        public Result themLoaiSanPham(LOAISANPHAM lsp)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();

            try
            {
                db.LOAISANPHAM.Add(lsp);
                db.SaveChanges();
                result._is_Success = true;
            }
            catch (Exception e)
            {
                result._is_Success = false;
                result._error = e.ToString();
                result._result = "Không thể thêm Mặt hàng";
            }

            return result;
        }

        /// <summary>
        /// Xóa mặt hàng
        /// </summary>
        /// <param name="maLoai"></param>
        /// <returns></returns>
        public Result xoaLoaiSanPham(string tenLoai)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.LOAISANPHAM.FirstOrDefault(b => b.TENLOAI == tenLoai);
            if (u != null)
            {
                try
                {
                    db.LOAISANPHAM.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa Loại sản phẩm";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Loại sản phẩm không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa loại sản phẩm
        /// </summary>
        /// <param name="mh"></param>
        /// <returns></returns>
        public Result suaLoaiSanPham(LOAISANPHAM lsp)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.LOAISANPHAM.FirstOrDefault(b => b.MALOAI == lsp.MALOAI);
            if (u != null)
            {
                try
                {
                    u = lsp;
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể sửa Loại sản phẩm";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Loại sản phẩm không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Lấy Danh sách Loại sản phẩm
        /// </summary>
        /// <param name="tenMatHang"></param>
        /// <returns></returns>
        public List<LOAISANPHAM> getAllLoaiSanPham()
        {
            List<LOAISANPHAM> result = new List<LOAISANPHAM>();

            var db = new NEWDAY_MARKETEntities();
            result = db.LOAISANPHAM.ToList();

            return result;
        }

        public int getMaLoaiSanPham(string tenloai)
        {
            int result = 0;

            var db = new NEWDAY_MARKETEntities();
            var lsp = db.LOAISANPHAM.FirstOrDefault(b => b.TENLOAI == tenloai);
            result = lsp.MALOAI;

            return result;
        }



        /// <summary>
        /// Lấy danh sánh Phiếu xuất hàng
        /// </summary>
        /// <param name="masp"></param>
        /// <returns></returns>
        public List<PHIEUXUATHANG> getPhieuXuatHang(string masp)
        {
            List<PHIEUXUATHANG> result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.PHIEUXUATHANG.Where(b => b.MASP == masp).ToList();

            return result;
        }

        public List<PHIEUXUATHANG> getAllPhieuXuatHang()
        {
            List<PHIEUXUATHANG> result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.PHIEUXUATHANG.ToList();

            return result;
        }

        /// <summary>
        /// Thêm phiếu xuất hàng mới
        /// </summary>
        /// <param name="pxh"></param>
        /// <returns></returns>
        public Result themPhieuXuatHang(PHIEUXUATHANG pxh)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();

            try
            {
                var newpxh = new PHIEUXUATHANG();
                newpxh.MASP = pxh.MASP;
                newpxh.SL = pxh.SL;
                db.PHIEUXUATHANG.Add(newpxh);
                db.SaveChanges();
                result._is_Success = true;
            }
            catch (Exception e)
            {
                result._is_Success = false;
                result._error = e.ToString();
                result._result = "Không thể thêm Phiếu xuất hàng";
            }

            return result;
        }

        /// <summary>
        /// Xóa phiếu xuất hàng
        /// </summary>
        /// <param name="stt"></param>
        /// <returns></returns>
        public Result xoaPhieuXuatHang(int stt)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.PHIEUXUATHANG.FirstOrDefault(b => b.STT == stt);
            if (u != null)
            {
                try
                {
                    db.PHIEUXUATHANG.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa Mặt hàng";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Mặt hàng không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa phiếu xuất hàng
        /// </summary>
        /// <param name="pxh"></param>
        /// <returns></returns>
        public Result suaPhieuXuatHang(PHIEUXUATHANG pxh)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.PHIEUXUATHANG.FirstOrDefault(b => b.STT == pxh.STT);
            if (u != null)
            {
                try
                {
                    u = pxh;
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể sửa mặt hàng";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Mặt hàng không tồn tại";
            }

            return result;
        }



        /// <summary>
        /// Lấy danh sánh Phiếu nhập hàng
        /// </summary>
        /// <param name="masp"></param>
        /// <returns></returns>
        public List<PHIEUNHAPHANG> getPhieuNhapHang(string masp)
        {
            List<PHIEUNHAPHANG> result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.PHIEUNHAPHANG.Where(b => b.MASP == masp).ToList();

            return result;
        }

        public List<PHIEUNHAPHANG> getAllPhieuNhapHang()
        {
            List<PHIEUNHAPHANG> result = null;

            var db = new NEWDAY_MARKETEntities();
            result = db.PHIEUNHAPHANG.ToList();

            return result;
        }

        /// <summary>
        /// Thêm phiếu nhập hàng mới
        /// </summary>
        /// <param name="pnh"></param>
        /// <returns></returns>
        public Result themPhieuNhapHang(PHIEUNHAPHANG pnh)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();

            try
            {
                var newpnh = new PHIEUNHAPHANG();
                newpnh.MASP = pnh.MASP;
                newpnh.SL = pnh.SL;
                db.PHIEUNHAPHANG.Add(newpnh);
                db.SaveChanges();
                result._is_Success = true;
            }
            catch (Exception e)
            {
                result._is_Success = false;
                result._error = e.ToString();
                result._result = "Không thể thêm";
            }

            return result;
        }

        /// <summary>
        /// Xóa phiếu nhập hàng
        /// </summary>
        /// <param name="stt"></param>
        /// <returns></returns>
        public Result xoaPhieuNhapHang(int stt)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.PHIEUNHAPHANG.FirstOrDefault(b => b.STT == stt);
            if (u != null)
            {
                try
                {
                    db.PHIEUNHAPHANG.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa Mặt hàng";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Mặt hàng không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa Phiết nhập hàng
        /// </summary>
        /// <param name="newpnh"></param>
        /// <returns></returns>
        public Result suaPhieuNhapHang(PHIEUNHAPHANG newpnh)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.PHIEUNHAPHANG.FirstOrDefault(b => b.STT == newpnh.STT);
            if (u != null)
            {
                try
                {
                    u = newpnh;
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể sửa mặt hàng";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Mặt hàng không tồn tại";
            }

            return result;
        }



        /// <summary>
        /// Lấy thông tin 1 hóa đơn
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public HOADON getHoaDonTheoMa(int mahd)
        {
            HOADON result;

            var db = new NEWDAY_MARKETEntities();
            result = db.HOADON.FirstOrDefault(b => b.MAHD == mahd);

            return result;
        }

        /// <summary>
        /// Lấy danh sách hóa đơn trong một khoảng thời gian date1 đến date2
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public HOADON getHoaDonTheoNgay(DateTime date1, DateTime date2)
        {
            HOADON result;

            var db = new NEWDAY_MARKETEntities();
            result = db.HOADON.Single(b => b.NGAYTT >= date1 && b.NGAYTT <= date2);

            return result;
        }

        public List<HOADON> getAllHoaDon()
        {
            List<HOADON> result;

            var db = new NEWDAY_MARKETEntities();
            result = db.HOADON.ToList();

            return result;
        }

        /// <summary>
        /// Thêm hóa đơn mới
        /// </summary>
        /// <param name="hd"></param>
        /// <returns></returns>
        public Result themHoaDon(HOADON hd)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();

            try
            {
                var newhd = new HOADON();
                newhd.MAHD = hd.MAHD;
                newhd.NGAYTT = hd.NGAYTT;
                newhd.TONGTIEN = hd.TONGTIEN;
                db.HOADON.Add(newhd);
                db.SaveChanges();
                result._is_Success = true;
            }
            catch (Exception e)
            {
                result._is_Success = false;
                result._error = e.ToString();
                result._result = "Không thể thêm hóa đơn mới";
            }
            return result;
        }

        /// <summary>
        /// Xóa hóa đơn
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public Result xoaHoaDon(int mahd)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.HOADON.FirstOrDefault(b => b.MAHD == mahd);
            if (u != null)
            {
                try
                {
                    db.HOADON.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa hóa đơn";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Hóa đơn không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa thông tin hóa đơn
        /// </summary>
        /// <param name="hd"></param>
        /// <returns></returns>
        public Result suaHoaDon(HOADON hd)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.HOADON.FirstOrDefault(b => b.MAHD == hd.MAHD);
            if (u != null)
            {
                try
                {
                    u = hd;
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể sửa hóa đơn";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Hóa đơn không tồn tại";
            }

            return result;
        }



        /// <summary>
        /// Lấy thông tin 1 chi tiết hóa đơn
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public List<CHITIETHOADON> getChiTietHoaDon(int mahd)
        {
            List<CHITIETHOADON> result;

            var db = new NEWDAY_MARKETEntities();
            result = db.CHITIETHOADON.Where(b => b.MAHD == mahd).ToList();

            return result;
        }

        /// <summary>
        /// Thêm chi tiết hóa đơn mới
        /// </summary>
        /// <param name="cthd"></param>
        /// <returns></returns>
        public Result themChiTietHoaDon(CHITIETHOADON cthd)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();

            try
            {
                var newcthd = new CHITIETHOADON();
                newcthd.MAHD = cthd.MAHD;
                newcthd.MASP = cthd.MASP;
                newcthd.SL = cthd.SL;
                newcthd.DONGIA = cthd.DONGIA;
                newcthd.CHIETKHAU = cthd.CHIETKHAU;
                newcthd.MAKHTT = cthd.MAKHTT;
                newcthd.THANHTIEN = cthd.THANHTIEN;

                db.CHITIETHOADON.Add(newcthd);
                db.SaveChanges();
                result._is_Success = true;
            }
            catch (Exception e)
            {
                result._is_Success = false;
                result._error = e.ToString();
                result._result = "Không thể thêm hóa đơn mới";
            }
            return result;
        }

        /// <summary>
        /// Xóa chi tiết hóa đơn
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public Result xoaChiTietHoaDonTheoSTT(int stt)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.CHITIETHOADON.FirstOrDefault(b => b.STT == stt);
            if (u != null)
            {
                try
                {
                    db.CHITIETHOADON.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa chi tiết hóa đơn";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Chi tiết hóa đơn không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Xóa chi tiết hóa đơn theo MAHD
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public Result xoaChiTietHoaDonTheoMAHD(int mahd)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.CHITIETHOADON.FirstOrDefault(b => b.STT == mahd);
            if (u != null)
            {
                try
                {
                    db.CHITIETHOADON.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa chi tiết hóa đơn";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Chi tiết hóa đơn không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa thông tin chi tiết hóa đơn
        /// </summary>
        /// <param name="hd"></param>
        /// <returns></returns>
        public Result suaChiTietHoaDon(CHITIETHOADON cthd)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.CHITIETHOADON.FirstOrDefault(b => b.STT == cthd.STT);
            if (u != null)
            {
                try
                {
                    u = cthd;
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể sửa hóa đơn";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Hóa đơn không tồn tại";
            }

            return result;
        }



        /// <summary>
        /// Lấy thông tin KHTT
        /// </summary>
        /// <param name="khtt"></param>
        /// <returns></returns>
        public KHTT getKhtt(KHTT khtt)
        {
            KHTT result;

            var db = new NEWDAY_MARKETEntities();
            result = db.KHTT.FirstOrDefault(b => b.MAKHTT == khtt.MAKHTT || b.CMND == khtt.CMND || b.SDT == khtt.SDT);

            return result;
        }

        public List<KHTT> getAllKhtt()
        {
            List<KHTT> result;

            var db = new NEWDAY_MARKETEntities();
            result = db.KHTT.ToList();

            return result;
        }

        /// <summary>
        /// Thêm khách hàng thân thiết
        /// </summary>
        /// <param name="khtt"></param>
        /// <returns></returns>
        public Result themKHTT(KHTT khtt)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.KHTT.FirstOrDefault(b => b.CMND == khtt.CMND || b.SDT == khtt.SDT);

            if (u == null)
            {
                try
                {
                    var newkhtt = new KHTT();
                    newkhtt.CMND = khtt.CMND;
                    newkhtt.SDT = khtt.SDT;
                    newkhtt.BAC = khtt.BAC;
                    newkhtt.THOIHAN = khtt.THOIHAN;
                    newkhtt.TIENTL = khtt.TIENTL;

                    db.KHTT.Add(newkhtt);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể thêm KHTT  mới";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "Thông tin KHTT đã tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Xóa KHTT
        /// </summary>
        /// <param name="khtt"></param>
        /// <returns></returns>
        public Result xoaKHTT(KHTT khtt)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.KHTT.FirstOrDefault(b => b.MAKHTT == khtt.MAKHTT || b.CMND == khtt.CMND || b.SDT == khtt.SDT);
            if (u != null)
            {
                try
                {
                    u = khtt;
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa KHTT";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "KHTT không tồn tại";
            }

            return result;
        }

        /// <summary>
        /// Sửa thông tin KHTT
        /// </summary>
        /// <param name="khtt"></param>
        /// <returns></returns>
        public Result suaKHTT(KHTT khtt)
        {
            var result = new Result(false, "", "");

            var db = new NEWDAY_MARKETEntities();
            var u = db.KHTT.FirstOrDefault(b => b.MAKHTT == khtt.MAKHTT || b.CMND == khtt.CMND || b.SDT == khtt.SDT);
            if (u != null)
            {
                try
                {
                    db.KHTT.Remove(u);
                    db.SaveChanges();
                    result._is_Success = true;
                }
                catch (Exception e)
                {
                    result._is_Success = false;
                    result._error = e.ToString();
                    result._result = "Không thể xóa KHTT";
                }
            }
            else
            {
                result._is_Success = false;
                result._result = "KHTT không tồn tại";
            }

            return result;
        }


    }
}
