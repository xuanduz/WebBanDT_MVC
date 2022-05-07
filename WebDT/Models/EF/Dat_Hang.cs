namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dat_Hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dat_Hang()
        {
            Dat_Hang_San_Pham = new HashSet<Dat_Hang_San_Pham>();
        }

        [Key]
        public int dh_Id { get; set; }

        public DateTime dh_NgayDat { get; set; }

        [Required]
        [StringLength(10)]
        public string dh_HinhThuc { get; set; }

        [Required]
        [StringLength(30)]
        public string dh_TrangThai { get; set; }

        public int dh_ndId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dat_Hang_San_Pham> Dat_Hang_San_Pham { get; set; }

        public virtual Nguoi_Dung Nguoi_Dung { get; set; }
    }
}
