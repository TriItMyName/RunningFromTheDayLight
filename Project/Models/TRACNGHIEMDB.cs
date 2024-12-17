using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Đồ_Án.Models
{
    public partial class TRACNGHIEMDB : DbContext
    {
        public TRACNGHIEMDB()
            : base("name=TRACNGHIEMDB2")
        {
        }

        public virtual DbSet<Chuong> Chuongs { get; set; }
        public virtual DbSet<NganHangCauHoi> NganHangCauHois { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<Thi> This { get; set; }
        public virtual DbSet<TracNghiem> TracNghiems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TracNghiem>()
                .Property(e => e.DapAnDung)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
