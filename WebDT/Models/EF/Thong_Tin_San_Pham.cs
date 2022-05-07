namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Thong_Tin_San_Pham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thong_Tin_San_Pham()
        {
            Dat_Hang_San_Pham = new HashSet<Dat_Hang_San_Pham>();
            Don_Nhap_San_Pham = new HashSet<Don_Nhap_San_Pham>();
            Thong_Tin_Gio_Hang = new HashSet<Thong_Tin_Gio_Hang>();
        }

        [Key]
        public int tt_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string tt_ManHinh { get; set; }

        [Required]
        [StringLength(100)]
        public string tt_Chip { get; set; }

        [Required]
        [StringLength(300)]
        public string tt_BoNho { get; set; }

        [Required]
        [StringLength(300)]
        public string tt_MauSac { get; set; }

        [Required]
        [StringLength(100)]
        public string tt_CameraTruoc { get; set; }

        [Required]
        [StringLength(100)]
        public string tt_CameraSau { get; set; }

        [Column(TypeName = "money")]
        public decimal tt_GiaBan { get; set; }

        [Column(TypeName = "money")]
        public decimal tt_GiaNhap { get; set; }

        public int m_SPId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dat_Hang_San_Pham> Dat_Hang_San_Pham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Don_Nhap_San_Pham> Don_Nhap_San_Pham { get; set; }

        public virtual San_Pham San_Pham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thong_Tin_Gio_Hang> Thong_Tin_Gio_Hang { get; set; }
    }
}
