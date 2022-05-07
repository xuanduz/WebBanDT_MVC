using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDT.Models
{
    public class CartPayment
    {
        public int dh_Id { get; set; }
        public DateTime dh_NgayDat { get; set; }
        public string dh_HinhThuc { get; set; }
        public int dh_TrangThai { get; set; }
        public int dh_ndid { get; set; }
    }
}