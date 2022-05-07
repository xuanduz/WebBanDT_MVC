using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDT.Models.EF;

namespace Model.DbAccessObj
{
    public class CartDAO
    {
        ShopDTDbContext db = null;

        public CartDAO()
        {
            db = new ShopDTDbContext();
        }

        public long Insert(Dat_Hang entity)
        {
            db.Dat_Hang.Add(entity);
            db.SaveChanges();
            return entity.dh_Id;
        }

        public bool InsertDHSP(Dat_Hang_San_Pham entity)
        {
            db.Dat_Hang_San_Pham.Add(entity);
            db.SaveChanges();
            return true;
        }

        public Nguoi_Dung GetIdUser(string userName)
        {
            return db.Nguoi_Dung.Where(x => x.nd_UserName == userName).FirstOrDefault();
        }


    }
}
