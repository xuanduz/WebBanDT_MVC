namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Danh_Muc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Danh_Muc()
        {
            San_Pham = new HashSet<San_Pham>();
        }

        [Key]
        public int dm_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string dm_Ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<San_Pham> San_Pham { get; set; }
    }
}
