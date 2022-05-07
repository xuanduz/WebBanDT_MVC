using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDT.Models.EF;

namespace Model.DbAccessObj
{
    public class CategoryDAO
    {
        ShopDTDbContext db = null;

        public CategoryDAO()
        {
            db = new ShopDTDbContext();
        }

        public List<NCCViewModel> GetNCC()
        {
            var imgNCC = from ncc in db.Nha_Cung_Cap
                         select new NCCViewModel()
                         {
                            id = ncc.ncc_Id,
                            ncc_Anh = ncc.ncc_Anh,
                            ncc_Ten = ncc.ncc_Name,
                        };
            return imgNCC.ToList();
        }
    }
}
