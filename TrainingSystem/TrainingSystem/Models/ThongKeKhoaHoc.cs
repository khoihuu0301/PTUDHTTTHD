using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingSystem.Models
{
    public class ThongKeKhoaHoc
    {
        [Key]
        [Display(Name = "Mã khóa học")]
        [Required]
        public int MaKH { get; set; }
        [Display(Name ="Tên khóa học")]
        public string TenMH { get; set; }
        [Display(Name = "Tháng")]
        public int Month { get; set; }
        [Display(Name = "Quý")]
        public int Quarter { get; set; }
        [Display(Name ="Năm")]
        public string Year { get; set; }
        [Display(Name ="Số lượng học viên")]
        public int SoLuongHocVien { get; set; }
        [Display(Name ="Điểm trung bình")]
        public float DTB { get; set; }
    }
}