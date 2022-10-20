using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingSystem.Models
{
    public class KhoaHoc
    {
        [Key]
        
        public int MaKhoaHoc { get; set; }
        [Required]
        public string TenKhoaHoc { get; set; }
        public string NguoiHuongDan { get; set; }
    }
}