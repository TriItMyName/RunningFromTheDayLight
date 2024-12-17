namespace Đồ_Án.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NganHangCauHoi")]
    public partial class NganHangCauHoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NganHangCauHoi()
        {
            Chuongs = new HashSet<Chuong>();
            TracNghiems = new HashSet<TracNghiem>();
        }

        [Key]
        public int MaNganHang { get; set; }

        [Required]
        [StringLength(255)]
        public string TenNganHang { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chuong> Chuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TracNghiem> TracNghiems { get; set; }
    }
}
