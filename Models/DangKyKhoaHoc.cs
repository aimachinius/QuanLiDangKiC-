using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiDangKiCSharp.Models
{
    public class DangKyKhoaHoc
    {
        [Key]
        public int MaDangKy { get; set; }

        [Required]
        [ForeignKey("HocVien")]
        public int MaHocVien { get; set; }

        [Required]
        [ForeignKey("KhoaHoc")]
        public int MaKhoaHoc { get; set; }

        [Required]
        public DateTime NgayDangKy { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}

