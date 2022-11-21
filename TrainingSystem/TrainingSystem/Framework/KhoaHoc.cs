namespace TrainingSystem.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoaHoc")]
    public partial class KhoaHoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKhoaHoc { get; set; }

        [StringLength(100)]
        public string TenKhoaHoc { get; set; }

        public int? MaNHD { get; set; }

        public virtual NguoiHuongDan NguoiHuongDan { get; set; }
    }
}
