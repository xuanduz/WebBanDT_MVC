namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class San_Pham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public San_Pham()
        {
            Danh_Gia = new HashSet<Danh_Gia>();
            Thong_Tin_San_Pham = new HashSet<Thong_Tin_San_Pham>();
        }

        [Key]
        public int sp_Id { get; set; }

        public double? sp_GiamGia { get; set; }

        [Required]
        [StringLength(50)]
        public string sp_Ten { get; set; }

        [StringLength(100)]
        public string sp_Anh { get; set; }

        [StringLength(200)]
        public string sp_GhiChu { get; set; }

        [Required]
        [StringLength(20)]
        public string sp_BaoHanh { get; set; }

        public int sp_dmId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danh_Gia> Danh_Gia { get; set; }

        public virtual Danh_Muc Danh_Muc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thong_Tin_San_Pham> Thong_Tin_San_Pham { get; set; }
    }
}
