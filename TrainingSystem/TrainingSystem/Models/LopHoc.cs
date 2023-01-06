using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingSystem.Models
{
    public class LopHoc
    {
        [Key]
        [Display(Name = "Mã khóa học")]
        [Required]
        public int MaKH { get; set; }

        [Display(Name = "Mã học viên")]
        public string MaHV { get; set; }

        [Display(Name = "Tên học viên")]
        public string TenHV { get; set; }

        [Display(Name = "Điểm")]
        public float Diem { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

    }
}