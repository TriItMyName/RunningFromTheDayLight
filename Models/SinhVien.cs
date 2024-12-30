namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            KetQuaThis = new HashSet<KetQuaThi>();
            LichThis = new HashSet<LichThi>();
        }

        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string Lop { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }

        [StringLength(10)]
        public string MaKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQuaThi> KetQuaThis { get; set; }

        public virtual Khoa Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichThi> LichThis { get; set; }

        public virtual User User { get; set; }
    }
}
