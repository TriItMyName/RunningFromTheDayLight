namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiangVien")]
    public partial class GiangVien
    {
        [Key]
        [StringLength(10)]
        public string MaGV { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }

        [StringLength(10)]
        public string MaKhoa { get; set; }

        public virtual Khoa Khoa { get; set; }

        public virtual User User { get; set; }
    }
}
