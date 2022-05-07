namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Danh_Gia
    {
        [Key]
        public int dg_id { get; set; }

        [Required]
        [StringLength(1500)]
        public string dg_NoiDung { get; set; }

        public int dg_ndID { get; set; }

        public int dg_spID { get; set; }

        public virtual Nguoi_Dung Nguoi_Dung { get; set; }

        public virtual San_Pham San_Pham { get; set; }
    }
}
