namespace RunningFromTheDayLight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bai")]
    public partial class Bai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bai()
        {
            TracNghiem = new HashSet<TracNghiem>();
        }

        [Key]
        public int MaBai { get; set; }

        [Required]
        [StringLength(200)]
        public string TenBai { get; set; }

        [StringLength(50)]
        public string MaMon { get; set; }

        public virtual Mon Mon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TracNghiem> TracNghiem { get; set; }
    }
}
