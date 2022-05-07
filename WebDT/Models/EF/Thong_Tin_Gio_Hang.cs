namespace WebDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Thong_Tin_Gio_Hang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ttgh_ghId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ttgh_spId { get; set; }

        public int ttgh_SoLuong { get; set; }

        public virtual Gio_Hang Gio_Hang { get; set; }

        public virtual Thong_Tin_San_Pham Thong_Tin_San_Pham { get; set; }
    }
}
