namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nguoi_Dung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nguoi_Dung()
        {
            Danh_Gia = new HashSet<Danh_Gia>();
            Dat_Hang = new HashSet<Dat_Hang>();
            Gio_Hang = new HashSet<Gio_Hang>();
        }

        [Key]
        public int nd_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string nd_HoVaTen { get; set; }

        [Required]
        [StringLength(100)]
        public string nd_UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string nd_Password { get; set; }

        [Required]
        [StringLength(100)]
        public string nd_Email { get; set; }

        [Required]
        [StringLength(100)]
        public string nd_DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string nd_SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danh_Gia> Danh_Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dat_Hang> Dat_Hang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gio_Hang> Gio_Hang { get; set; }
    }
}
