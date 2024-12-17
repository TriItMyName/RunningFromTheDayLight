namespace Đồ_Án.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TracNghiem")]
    public partial class TracNghiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TracNghiem()
        {
            This = new HashSet<Thi>();
        }

        [Key]
        public int MaCauHoi { get; set; }

        public int? MaNganHang { get; set; }

        public int? MaChuong { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(255)]
        public string DapAnA { get; set; }

        [Required]
        [StringLength(255)]
        public string DapAnB { get; set; }

        [Required]
        [StringLength(255)]
        public string DapAnC { get; set; }

        [Required]
        [StringLength(255)]
        public string DapAnD { get; set; }

        [Required]
        [StringLength(1)]
        public string DapAnDung { get; set; }

        [StringLength(100)]
        public string ChuyenNganh { get; set; }

        [Required]
        [StringLength(20)]
        public string MucDo { get; set; }

        public virtual Chuong Chuong { get; set; }

        public virtual NganHangCauHoi NganHangCauHoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thi> This { get; set; }
    }
}
