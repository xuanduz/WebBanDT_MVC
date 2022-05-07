namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Don_Nhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Don_Nhap()
        {
            Don_Nhap_San_Pham = new HashSet<Don_Nhap_San_Pham>();
        }

        [Key]
        public int dn_Id { get; set; }

        public DateTime dn_NgayNhap { get; set; }

        public int dn_nccId { get; set; }

        public int dn_AdminAccount { get; set; }

        public virtual AdminAccount AdminAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Don_Nhap_San_Pham> Don_Nhap_San_Pham { get; set; }

        public virtual Nha_Cung_Cap Nha_Cung_Cap { get; set; }
    }
}
