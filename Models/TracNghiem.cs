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

        public string NoiDung { get; set; }

        public string DapAnA { get; set; }

        public string DapAnB { get; set; }

        public string DapAnC { get; set; }

        public string DapAnD { get; set; }

        [StringLength(1)]
        public string DapAnDung { get; set; }

        [StringLength(50)]
        public string LoaiCauHoi { get; set; }

        public int? MaBai { get; set; }

        public virtual Bai Bai { get; set; }
    }
}
