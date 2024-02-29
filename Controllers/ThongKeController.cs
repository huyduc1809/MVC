using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteThuCungBento.Models;

namespace WebsiteThuCungBento.Controllers
{
    public class ThongKeController : Controller
    {
        DataClassesDataContext data = new DataClassesDataContext();
        // GET: ThongKe
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("dangnhap", "Admin");
            else 
                ViewBag.TongDoanhThu = ThongKeTongDoanhThu();
                ViewBag.TongDonHang = ThongKeDonHang();
                ViewBag.TongSanPham = ThongKeSanPham();
                ViewBag.TongKhachHang = ThongKeKhachHang();
                ViewBag.TongAdmin = ThongKeNhanVien();
            return View();
        }
        
        public double ThongKeDonHang()
        {
            double slDonHang = data.DONDATHANGs.Count();
            return slDonHang;
        }

        public double ThongKeSanPham()
        {
            double slDonHang = data.SANPHAMs.Count();
            return slDonHang;
        }

        public double ThongKeKhachHang()
        {
            double slDonHang = data.KHACHHANGs.Count();
            return slDonHang;
        }

        public double ThongKeNhanVien()
        {
            double slDonHang = data.ADMINs.Count();
            return slDonHang;
        }

        public decimal ThongKeTongDoanhThu()
        {
            decimal TongDoanhThu = decimal.Parse(data.CTDONDATHANGs.Sum(n => n.SOLUONG * n.DONGIA).ToString());
            return TongDoanhThu;
        }

        public decimal ThongKeDoanhThuThang(int Thang, int Nam)
        {
            var listDH = data.DONDATHANGs.Where(n => n.NGAYDAT.Month == Thang && n.NGAYDAT.Year == Nam);
            decimal TongTien = 0;
            foreach(var item in listDH)
            {
                TongTien += decimal.Parse(item.CTDONDATHANGs.Sum(n => n.SOLUONG * n.DONGIA).ToString());
            }     
            return TongTien;
        }
    }
}