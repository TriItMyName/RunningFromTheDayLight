namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuocThi")]
    public partial class CuocThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuocThi()
        {
            KetQuaThis = new HashSet<KetQuaThi>();
        }

        [Key]
        public int MaCuocThi { get; set; }

        [Required]
        [StringLength(50)]
        public string MaMon { get; set; }

        public DateTime NgayThi { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        public virtual Mon Mon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQuaThi> KetQuaThis { get; set; }
    }
}
