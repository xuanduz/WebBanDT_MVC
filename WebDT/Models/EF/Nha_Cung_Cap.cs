namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nha_Cung_Cap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nha_Cung_Cap()
        {
            Don_Nhap = new HashSet<Don_Nhap>();
        }

        [Key]
        public int ncc_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ncc_Email { get; set; }

        [Required]
        [StringLength(20)]
        public string ncc_SoDienThoai { get; set; }

        [Required]
        [StringLength(100)]
        public string ncc_Website { get; set; }

        [Required]
        [StringLength(100)]
        public string ncc_Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ncc_Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Don_Nhap> Don_Nhap { get; set; }
    }
}
