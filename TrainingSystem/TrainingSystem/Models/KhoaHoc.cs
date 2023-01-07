using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingSystem.Models
{
    public class KhoaHoc
    {
        [Key]
        [Display(Name = "Mã khóa học")]
        [Required]
        public int MaKH { get; set; }
        [Display(Name ="Mã người hướng dẫn")]
        public string MaNHD { get; set; }
        [Display(Name ="Mã môn học")]
        public int MaMH { get; set; }

        [Display(Name = "Tên môn học")]
        public string TenMH { get; set; }

        [Display(Name = "Tên người hướng dẫn")]
        public string TenNHD { get; set; }

        [Display(Name = "Cách đánh giá")]
        public string CachDanhGia { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        public string NgayBatDau { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public string NgayKetThuc { get; set; }

    }
}