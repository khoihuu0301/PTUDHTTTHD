using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingSystem.Models
{
    public class HocVien
    {
        [Key]
        [Display(Name = "Mã học viên")]
        [Required]
        public string MaHV { get; set; }

        [Display(Name = "Tên học viên")]
        public string TenHV { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SDT_HV { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi_HV { get; set; }

        [Display(Name = "Email")]
        public string Email_HV { get; set; }

    }
}