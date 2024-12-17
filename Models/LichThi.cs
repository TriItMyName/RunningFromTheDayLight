namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichThi")]
    public partial class LichThi
    {
        [Key]
        public int MaLichThi { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSV { get; set; }

        [Required]
        [StringLength(50)]
        public string MaMon { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public int ThoiGianThi { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPhong { get; set; }

        public virtual Mon Mon { get; set; }

        public virtual PhongThi PhongThi { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
