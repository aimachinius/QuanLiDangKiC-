using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace QuanLiDangKiCSharp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") // Kết nối với chuỗi kết nối trong Web.config
        {
        }

        // DbSet đại diện cho các bảng trong cơ sở dữ liệu
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ nhiều-nhiều giữa HocVien và KhoaHoc thông qua DangKyKhoaHoc
            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasRequired(d => d.HocVien)
                .WithMany(h => h.DangKyKH)
                .HasForeignKey(d => d.MaHocVien);

            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasRequired(d => d.KhoaHoc)
                .WithMany(k => k.DangKyKH)
                .HasForeignKey(d => d.MaKhoaHoc);
        }

        public System.Data.Entity.DbSet<QuanLiDangKiCSharp.Models.User> Users { get; set; }
    }
}