namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TracNghiem")]
    public partial class TracNghiem
    {
        public int ID { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        public string DapAnA { get; set; }

        [Required]
        public string DapAnB { get; set; }

        [Required]
        public string DapAnC { get; set; }

        [Required]
        public string DapAnD { get; set; }

        [Required]
        [StringLength(1)]
        public string DapAnDung { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiCauHoi { get; set; }

        public string AudioFileName { get; set; }

        public int? MaBai { get; set; }

        public virtual Bai Bai { get; set; }
    }
}
