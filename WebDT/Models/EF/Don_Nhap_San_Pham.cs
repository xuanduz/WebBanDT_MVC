namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Don_Nhap_San_Pham
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dnsp_dnId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dnsp_spId { get; set; }

        public int dnsp_SoLuong { get; set; }

        public virtual Don_Nhap Don_Nhap { get; set; }

        public virtual Thong_Tin_San_Pham Thong_Tin_San_Pham { get; set; }
    }
}
