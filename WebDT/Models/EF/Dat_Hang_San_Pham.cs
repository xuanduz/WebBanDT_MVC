namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dat_Hang_San_Pham
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dhsp_dhId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dhsp_spId { get; set; }

        public int dhsp_SoLuong { get; set; }

        public virtual Dat_Hang Dat_Hang { get; set; }

        public virtual Thong_Tin_San_Pham Thong_Tin_San_Pham { get; set; }
    }
}
