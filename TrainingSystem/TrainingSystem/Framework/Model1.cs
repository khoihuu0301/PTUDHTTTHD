using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TrainingSystem.Framework
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DTB")
        {
        }

        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<NguoiHuongDan> NguoiHuongDans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
