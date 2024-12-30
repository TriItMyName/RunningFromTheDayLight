namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeThiNgauNhien")]
    public partial class DeThiNgauNhien
    {
        [Key]
        public int MaDeNgauNhien { get; set; }

        [StringLength(200)]
        public string TenDe { get; set; }

        [Required]
        [StringLength(50)]
        public string MaMon { get; set; }

        public DateTime NgayTao { get; set; }

        public string CacCauHoi { get; set; }

        public int ThoiGianThi { get; set; }
    }
}
