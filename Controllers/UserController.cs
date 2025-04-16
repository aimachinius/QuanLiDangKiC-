using QuanLiDangKiCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiDangKiCSharp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            string tk = Session["TenDangNhap"] as string;
            if (string.IsNullOrEmpty(tk))
                return RedirectToAction("Login", "Account");
            var hv = db.HocViens.FirstOrDefault(x => x.TaiKhoan == tk);
            if (hv == null)
            {
                // Nếu không tìm thấy học viên, bạn có thể chuyển đến trang lỗi hoặc thông báo khác.
                return HttpNotFound("Học viên không tồn tại.");
            }
            return View(hv);
        }

        public ActionResult KhoaHoc()
        {
            string tk = Session["TenDangNhap"] as string;
            var hocVien = db.HocViens.FirstOrDefault(x => x.TaiKhoan == tk);
            if(hocVien == null)
            {
                // Nếu không tìm thấy học viên, bạn có thể chuyển đến trang lỗi hoặc thông báo khác.
                return HttpNotFound("Học viên không tồn tại.");
            }
            var listKhoaHoc = db.KhoaHocs.ToList();
            var listKHDaDangKy = db.DangKyKhoaHocs.Where(x => x.MaHocVien == hocVien.MaHocVien).ToList();

            //hashmap lưu mã khóa học và số lượng học viên đã đăng ký
            var SoLuonngHienTai = listKhoaHoc.ToDictionary(
                x => x.MaKhoaHoc,
                x => db.DangKyKhoaHocs.Count( c => c.MaKhoaHoc == x.MaKhoaHoc)
            );
            ViewBag.DanhSachDangKy = listKHDaDangKy;
            ViewBag.SoLuongDangKy = SoLuonngHienTai;

            return View(listKhoaHoc);
        }

        public ActionResult DaDangKy()
        {
            string tk = Session["TenDangNhap"] as string;
            var hv = db.HocViens.FirstOrDefault(x => x.TaiKhoan == tk);
            if (hv == null)
            {
                return HttpNotFound("Học viên không tồn tại.");
            }
            List<KhoaHoc> dsKhoaHoc = listDaDangKy(hv);
            Console.WriteLine(dsKhoaHoc);
            return View(dsKhoaHoc);
        }

        public ActionResult DangKy(int maKhoaHoc)
        {
            string tk = Session["TenDangNhap"] as string;
            if (string.IsNullOrEmpty(tk))
                return RedirectToAction("Login", "Account");
            var hocVien = db.HocViens.FirstOrDefault(x => x.TaiKhoan == tk);
            if (hocVien == null)
            {
                // Nếu không tìm thấy học viên, bạn có thể chuyển đến trang lỗi hoặc thông báo khác.
                return HttpNotFound("Học viên không tồn tại.");
            }

            var dk = new DangKyKhoaHoc
            {
                MaHocVien = hocVien.MaHocVien,
                MaKhoaHoc = maKhoaHoc,
                NgayDangKy = DateTime.Now
            };
            db.DangKyKhoaHocs.Add(dk);
            db.SaveChanges();
            return RedirectToAction("DaDangKy");
        }
        public List<KhoaHoc> listDaDangKy(HocVien hocVien)
        {
            List<KhoaHoc> listDDK = new List<KhoaHoc>();
            foreach (var item in db.DangKyKhoaHocs)
            {
                if (item.MaHocVien == hocVien.MaHocVien)
                {
                    var kh = db.KhoaHocs.FirstOrDefault(x => x.MaKhoaHoc == item.MaKhoaHoc);
                    if (kh != null)
                    {
                        listDDK.Add(kh);
                    }
                }
            }
            return listDDK;
        }
        public List<KhoaHoc> listKhoaHoc()
        {
            var listKhoaHoc = db.KhoaHocs.ToList();
            return listKhoaHoc;
        }
        public ActionResult HuyDangKy(int maKhoaHoc)
        {
            string tk = Session["TenDangNhap"] as string;
            if (string.IsNullOrEmpty(tk))
                return RedirectToAction("Login", "Account");

            var hocVien = db.HocViens.FirstOrDefault(h => h.TaiKhoan == tk);
            if (hocVien == null)
                return RedirectToAction("Login", "Account");

            var dk = db.DangKyKhoaHocs
                       .FirstOrDefault(d => d.MaHocVien == hocVien.MaHocVien && d.MaKhoaHoc == maKhoaHoc);

            if (dk != null && dk.KhoaHoc.ThoiGianKhaiGiang > DateTime.Now)
            {
                db.DangKyKhoaHocs.Remove(dk);
                db.SaveChanges();
            }

            return RedirectToAction("DaDangKy");
        }

    }
}