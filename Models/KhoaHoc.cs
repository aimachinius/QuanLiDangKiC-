using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiDangKiCSharp.Models
{
    public class KhoaHoc
    {
        [Key]
        public int MaKhoaHoc { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKhoaHoc { get; set; }

        [Required]
        [StringLength(100)]
        public string GiangVien { get; set; }

        [Required]
        public DateTime ThoiGianKhaiGiang { get; set; }

        [Required]
        public double HocPhi { get; set; }

        [Required]
        public int SoLuongHocVienToiDa { get; set; }

        public virtual ICollection<DangKyKhoaHoc> DangKyKH { get; set; }
    }
}
