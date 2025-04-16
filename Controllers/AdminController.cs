using QuanLiDangKiCSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiDangKiCSharp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index() => View();
            
        public ActionResult DanhSachHocVien()
        {
            return View("~/Views/HocViens/Index.cshtml", db.HocViens.ToList());
        }
        public ActionResult DanhSachKhoaHoc() => View("~/Views/KhoaHocs/Index.cshtml", db.KhoaHocs.ToList());

        public ActionResult DanhSachDangKy() => View("~/Views/DangKyKhoaHocs/Index.cshtml", db.DangKyKhoaHocs.ToList());
        
        
    }
}