using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDT.Models
{
    public class RegisterModel
    {
        [Key]
        public int nd_Id { get; set; }

        
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage = "Nhập họ tên")]
        [StringLength(100)]
        public string nd_HoVaTen { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        public string nd_UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [StringLength(20, MinimumLength =6, ErrorMessage = "Độ dài mật khẩu tối thiểu 6 ký tự")]
        public string nd_Password { get; set; }

        [Display(Name = "Xác nhập mật khẩu")]
        [Compare("nd_Password", ErrorMessage = "Xác nhận mật khẩu lỗi")]
        public string nd_PasswordConfirm { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Nhập địa chỉ email")]
        public string nd_Email { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Nhập địa chỉ")]
        public string nd_DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Nhập số điện thoại")]
        public string nd_SoDienThoai { get; set; }
    }
}