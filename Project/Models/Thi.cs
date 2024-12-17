namespace Đồ_Án.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thi")]
    public partial class Thi
    {
        [Key]
        public int MaThi { get; set; }

        public int? MaSV { get; set; }

        public int? MaCauHoi { get; set; }

        public double? Diem { get; set; }

        public bool? GianLan { get; set; }

        public virtual SinhVien SinhVien { get; set; }

        public virtual TracNghiem TracNghiem { get; set; }
    }
}
