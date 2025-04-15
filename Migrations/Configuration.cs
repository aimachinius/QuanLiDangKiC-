namespace QuanLiDangKiC_.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using QuanLiDangKiCSharp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLiDangKiCSharp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(QuanLiDangKiCSharp.Models.ApplicationDbContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //    //  to avoid creating duplicate seed data.
        //}
        protected override void Seed(QuanLiDangKiCSharp.Models.ApplicationDbContext context)
        {
            ////// Thêm dữ liệu mẫu cho bảng HocVien
            ////context.HocViens.AddOrUpdate(
            ////    h => h.TaiKhoan,
            ////    new HocVien { HoTen = "Nguyen Van A", NgaySinh = new DateTime(1990, 1, 1), SoDienThoai = "0123456789", Email = "a@gmail.com", TaiKhoan = "nguyenvana", MatKhau = "123456" },
            ////    new HocVien { HoTen = "Tran Thi B", NgaySinh = new DateTime(1995, 5, 5), SoDienThoai = "0987654321", Email = "b@gmail.com", TaiKhoan = "tranthib", MatKhau = "654321" }
            ////);

            ////// Thêm dữ liệu mẫu cho bảng KhoaHoc
            ////context.KhoaHocs.AddOrUpdate(
            ////    k => k.TenKhoaHoc,
            ////    new KhoaHoc { TenKhoaHoc = "Lap Trinh C#", GiangVien = "Nguyen Van C", ThoiGianKhaiGiang = DateTime.Now.AddDays(10), HocPhi = 5000000, SoLuongHocVienToiDa = 30 },
            ////    new KhoaHoc { TenKhoaHoc = "Lap Trinh Java", GiangVien = "Tran Van D", ThoiGianKhaiGiang = DateTime.Now.AddDays(20), HocPhi = 6000000, SoLuongHocVienToiDa = 25 }
            ////);
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //// Tạo vai trò Admin nếu chưa tồn tại
            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var role = new IdentityRole("Admin");
            //    roleManager.Create(role);

            //    // Tạo tài khoản Admin mặc định
            //    var adminUser = new ApplicationUser { UserName = "admin", Email = "admin@example.com" };
            //    var result = userManager.Create(adminUser, "Admin@123");
            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRole(adminUser.Id, "Admin");
            //    }
            //}

            //// Tạo vai trò HocVien nếu chưa tồn tại
            //if (!roleManager.RoleExists("HocVien"))
            //{
            //    var role = new IdentityRole("HocVien");
            //    roleManager.Create(role);
            //}
        }

    }
}
