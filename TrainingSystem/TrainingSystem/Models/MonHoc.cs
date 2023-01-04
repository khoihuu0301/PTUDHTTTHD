using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingSystem.Models
{
    public class MonHoc
    {
        [Key]
        [Display(Name = "Mã môn học")]
        [Required]
        public int MaMH { get; set; }

        [Display(Name = "Tên môn học")]
        public string TenMH { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Mục tiêu")]
        public string MucTieu { get; set; }
        

    }
}