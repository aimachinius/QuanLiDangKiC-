using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLiDangKiCSharp.Models
{
    public class HocVien
    {
        [Key]
        public int MaHocVien { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public virtual ICollection<DangKyKhoaHoc> DangKyKH { get; set; }

    }
}
