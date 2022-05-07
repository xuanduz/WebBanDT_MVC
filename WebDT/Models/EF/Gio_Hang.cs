namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gio_Hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gio_Hang()
        {
            Thong_Tin_Gio_Hang = new HashSet<Thong_Tin_Gio_Hang>();
        }

        [Key]
        public int gh_Id { get; set; }

        public int gh_ndId { get; set; }

        public virtual Nguoi_Dung Nguoi_Dung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thong_Tin_Gio_Hang> Thong_Tin_Gio_Hang { get; set; }
    }
}
