namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQuaThi")]
    public partial class KetQuaThi
    {
        [Key]
        public int MaKetQua { get; set; }

        [StringLength(10)]
        public string MaSV { get; set; }

        public int? MaCuocThi { get; set; }

        public double? Diem { get; set; }

        public int? ThoiGianLamBai { get; set; }

        public DateTime? NgayThi { get; set; }

        public virtual CuocThi CuocThi { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
