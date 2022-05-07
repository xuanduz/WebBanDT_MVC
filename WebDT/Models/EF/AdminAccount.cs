namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminAccount")]
    public partial class AdminAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminAccount()
        {
            Don_Nhap = new HashSet<Don_Nhap>();
        }

        [Key]
        public int ad_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ad_HoVaTen { get; set; }

        [Required]
        [StringLength(100)]
        public string ad_UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string ad_PassWord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Don_Nhap> Don_Nhap { get; set; }
    }
}
