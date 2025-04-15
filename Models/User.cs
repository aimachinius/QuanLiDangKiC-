using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace QuanLiDangKiCSharp.Models
{

    public class User
    {
        [Key]
        [Required]
        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Admin?")]
        public bool VaiTro { get; set; } // true = Admin, false = Học viên

        [ForeignKey("HocVien")]
        [Display(Name = "Mã học viên")]
        public int? MaHocVien { get; set; }

        public virtual HocVien HocVien { get; set; }
    }

}