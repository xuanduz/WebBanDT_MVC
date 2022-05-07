using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDT.Models
{
    [Serializable]
    public class CartItem
    {
        public ProductInfoModel Product { get; set; }
        public int Quantity { get; set; }
    }
}