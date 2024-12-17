namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanLy")]
    public partial class QuanLy
    {
        [Key]
        [StringLength(10)]
        public string MaAdmin { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }

        public virtual User User { get; set; }
    }
}
