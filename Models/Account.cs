using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiDangKiCSharp.Models
{
    public class Account
    {

        [Key]
        [Required]
        public string TK { get; set; } // username
        [Required]
        public string MK { get; set; } // password
        [Required]
        public bool Role { get; set; } // true for admin, false for user
                
    }
}