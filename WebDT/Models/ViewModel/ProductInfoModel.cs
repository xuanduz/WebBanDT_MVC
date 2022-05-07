using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductInfoModel
    {
        public int sp_Id { get; set; }
        public double? sp_GiamGia { get; set; }

        public string sp_Ten { get; set; }

        public string sp_Anh { get; set; }

        public string sp_GhiChu { get; set; }

        public string sp_BaoHanh { get; set; }

        // Thong tin san pham
        public int tt_Id { get; set; }

        public string tt_ManHinh { get; set; }

        public string tt_Chip { get; set; }

        public string tt_BoNho { get; set; }

        public string tt_MauSac { get; set; }

        public string tt_CameraTruoc { get; set; }

        public string tt_CameraSau { get; set; }

        public decimal tt_GiaBan { get; set; }

        public decimal tt_GiaNhap { get; set; }
    }
}
