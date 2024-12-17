namespace Đồ_Án.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chuong")]
    public partial class Chuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chuong()
        {
            TracNghiems = new HashSet<TracNghiem>();
        }

        [Key]
        public int MaChuong { get; set; }

        public int STT { get; set; }

        [Required]
        [StringLength(255)]
        public string TenChuong { get; set; }

        public int? MaNganHang { get; set; }

        public virtual NganHangCauHoi NganHangCauHoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TracNghiem> TracNghiems { get; set; }
    }
}
