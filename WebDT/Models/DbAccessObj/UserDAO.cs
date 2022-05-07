using Model.ProcExcute;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDT.Models.EF;

namespace Model.DbAccessObj
{
    public class UserDAO
    {
        ShopDTDbContext db = null;

        public UserDAO()
        {
            db = new ShopDTDbContext();
        }
        public long Insert(AdminAccount entity)
        {
            db.AdminAccounts.Add(entity);
            db.SaveChanges();
            return entity.ad_Id;
        }

        public int Login(string userName, string password)
        {
            var res = db.AdminAccounts.SingleOrDefault(x => x.ad_UserName == userName);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.ad_PassWord == password)
                {
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
        }

        public long InsertClient(Nguoi_Dung entity)
        {
            db.Nguoi_Dung.Add(entity);
            db.SaveChanges();
            return entity.nd_Id;
        }

        public long LoginClient(string uName, string pWord)
        {
            var res = db.Nguoi_Dung.SingleOrDefault(x => x.nd_UserName == uName);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.nd_Password == pWord)
                {
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
        }

        public bool UpdateUser(Nguoi_Dung entity)
        {
            try
            {
                var user = db.Nguoi_Dung.Find(entity.nd_Id);
                user.nd_HoVaTen = entity.nd_HoVaTen;
                user.nd_Email = entity.nd_Email;
                user.nd_DiaChi = entity.nd_DiaChi;
                user.nd_SoDienThoai = entity.nd_SoDienThoai;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateNCC(Nha_Cung_Cap entity)
        {
            try
            {
                var ncc = db.Nha_Cung_Cap.Find(entity.ncc_Id);
                ncc.ncc_Name = entity.ncc_Name;
                ncc.ncc_Email = entity.ncc_Email;
                ncc.ncc_Website = entity.ncc_Website;
                ncc.ncc_SoDienThoai = entity.ncc_SoDienThoai;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Nguoi_Dung.Find(id);
                db.Nguoi_Dung.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Nguoi_Dung ViewDetailUser(int id)
        {
            return db.Nguoi_Dung.Find(id);
        }

        public Nguoi_Dung ViewDetailUser(string userName)
        {
            return db.Nguoi_Dung.Where(x => x.nd_UserName == userName).FirstOrDefault();
        }

        public IEnumerable<Nguoi_Dung> GetAllClient()
        {
            return db.Nguoi_Dung.OrderByDescending(x => x.nd_Id).ToList();
        }

        public IEnumerable<GetInfoProduct> GetInfoProductForAdmin()
        {
            var res = db.Database.SqlQuery<GetInfoProduct>("GetInfoProductForAdmin").ToList();
            return res;
        }

        public IEnumerable<TotalSalesToday> TotalSalesToday()
        {
            return db.Database.SqlQuery<TotalSalesToday>("Today").ToList();
        }

        public Chart GetChart(string year)
        {
            return db.Database.SqlQuery<Chart>("select * from doanhthu(" + year + ")").FirstOrDefault();
        }

        public AdminAccount GetByUserName(string userName)
        {
            return db.AdminAccounts.SingleOrDefault(x => x.ad_UserName == userName);
        }

        public Nguoi_Dung GetByUserNameClient(string userName)
        {
            return db.Nguoi_Dung.SingleOrDefault(x => x.nd_UserName == userName);
        }


        public List<Nha_Cung_Cap> GetNCC()
        {
            return db.Nha_Cung_Cap.ToList();
        }

        public Nha_Cung_Cap ViewDetailNCC(int id)
        {
            return db.Nha_Cung_Cap.Find(id);
        }

        public IEnumerable<GetOrders> GetOrders()
        {
            return db.Database.SqlQuery<GetOrders>("GetOrders").ToList();
        }

        public bool CheckUserName(string uName)
        {
            return db.Nguoi_Dung.Count(x => x.nd_UserName == uName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Nguoi_Dung.Count(x => x.nd_Email == email) > 0;
        }
    }
}
