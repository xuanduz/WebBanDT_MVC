using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using WebDT.Models.EF;

namespace Model.DbAccessObj
{
    public class ProductInfoDAO
    {
        ShopDTDbContext db = null;

        public ProductInfoDAO()
        {
            db = new ShopDTDbContext();
        }
        public IEnumerable<ProductInfoModel> ListAllProductPaging(string searchCategory, int page, int pageSize)
        {
            var model = from a in db.San_Pham
                        join b in db.Thong_Tin_San_Pham
                        on a.sp_Id equals b.m_SPId
                        select new ProductInfoModel()
                        {
                            sp_Id = a.sp_Id,
                            sp_GiamGia = a.sp_GiamGia,
                            sp_Ten = a.sp_Ten,
                            sp_Anh = a.sp_Anh,
                            sp_GhiChu = a.sp_GhiChu,
                            sp_BaoHanh = a.sp_BaoHanh,
                            tt_Id = b.tt_Id,
                            tt_ManHinh = b.tt_ManHinh,
                            tt_Chip = b.tt_Chip,
                            tt_BoNho = b.tt_BoNho,
                            tt_MauSac = b.tt_MauSac,
                            tt_CameraSau = b.tt_CameraSau,
                            tt_CameraTruoc = b.tt_CameraTruoc,
                            tt_GiaBan = b.tt_GiaBan,
                            tt_GiaNhap = b.tt_GiaNhap
                        };
            if (!string.IsNullOrEmpty(searchCategory))
            {
                return model.Where(x => x.sp_Ten.Contains(searchCategory)).OrderBy(x => Guid.NewGuid()).ToPagedList(page, pageSize);
            }
            return model.OrderBy(x => Guid.NewGuid()).ToPagedList(page, pageSize);
        }
        public List<ProductInfoModel> GetTop10SP()
        {
            return db.Database.SqlQuery<ProductInfoModel>("Top10SP").ToList();
        }
        public List<ProductInfoModel> ListProduct(int number)
        {
            var model = from a in db.San_Pham
                        join b in db.Thong_Tin_San_Pham
                        on a.sp_Id equals b.m_SPId
                        select new ProductInfoModel()
                        {
                            sp_Id = a.sp_Id,
                            sp_GiamGia = a.sp_GiamGia,
                            sp_Ten = a.sp_Ten,
                            sp_Anh = a.sp_Anh,
                            sp_GhiChu = a.sp_GhiChu,
                            sp_BaoHanh = a.sp_BaoHanh,
                            tt_Id = b.tt_Id,
                            tt_ManHinh = b.tt_ManHinh,
                            tt_Chip = b.tt_Chip,
                            tt_BoNho = b.tt_BoNho,
                            tt_MauSac = b.tt_MauSac,
                            tt_CameraSau = b.tt_CameraSau,
                            tt_CameraTruoc = b.tt_CameraTruoc,
                            tt_GiaBan = b.tt_GiaBan,
                            tt_GiaNhap = b.tt_GiaNhap
                        };
            if(number > 0)
            {
                return model.OrderBy(x => x.tt_Id).Take(number - 1).ToList();
            }
            return model.OrderBy(x => x.tt_Id).ToList();
        }
        public ProductInfoModel GetProduct(string nameProduct, string memoryProduct, string colorProduct)
        {
            var model = from a in db.San_Pham
                        join b in db.Thong_Tin_San_Pham
                        on a.sp_Id equals b.m_SPId
                        where a.sp_Ten == nameProduct
                        && b.tt_BoNho == memoryProduct
                        && b.tt_MauSac == colorProduct
                        select new ProductInfoModel()
                        {
                            sp_Id = a.sp_Id,
                            sp_GiamGia = a.sp_GiamGia,
                            sp_Ten = a.sp_Ten,
                            sp_Anh = a.sp_Anh,
                            sp_GhiChu = a.sp_GhiChu,
                            sp_BaoHanh = a.sp_BaoHanh,
                            tt_Id = b.tt_Id,
                            tt_ManHinh = b.tt_ManHinh,
                            tt_Chip = b.tt_Chip,
                            tt_BoNho = b.tt_BoNho,
                            tt_MauSac = b.tt_MauSac,
                            tt_CameraSau = b.tt_CameraSau,
                            tt_CameraTruoc = b.tt_CameraTruoc,
                            tt_GiaBan = b.tt_GiaBan,
                            tt_GiaNhap = b.tt_GiaNhap
                        };
            return model.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
        public ProductInfoModel GetProduct(int productId)
        {
            var model = from a in db.San_Pham
                        join b in db.Thong_Tin_San_Pham
                        on a.sp_Id equals b.m_SPId
                        where b.tt_Id == productId
                        select new ProductInfoModel()
                        {
                            sp_Id = a.sp_Id,
                            sp_GiamGia = a.sp_GiamGia,
                            sp_Ten = a.sp_Ten,
                            sp_Anh = a.sp_Anh,
                            sp_GhiChu = a.sp_GhiChu,
                            sp_BaoHanh = a.sp_BaoHanh,
                            tt_Id = b.tt_Id,
                            tt_ManHinh = b.tt_ManHinh,
                            tt_Chip = b.tt_Chip,
                            tt_BoNho = b.tt_BoNho,
                            tt_MauSac = b.tt_MauSac,
                            tt_CameraSau = b.tt_CameraSau,
                            tt_CameraTruoc = b.tt_CameraTruoc,
                            tt_GiaBan = b.tt_GiaBan,
                            tt_GiaNhap = b.tt_GiaNhap
                        };
            return model.OrderBy(x => x.tt_Id).FirstOrDefault();
        }

        public bool UpdateProduct(ProductInfoModel product)
        {
            try
            {
                var sp = db.San_Pham.Find(product.sp_Id);
                sp.sp_GiamGia = product.sp_GiamGia;
                sp.sp_Ten = product.sp_Ten;
                sp.sp_BaoHanh = product.sp_BaoHanh;
                sp.sp_Anh = product.sp_Anh;
                sp.sp_GhiChu = product.sp_GhiChu;

                var tt = db.Thong_Tin_San_Pham.Find(product.tt_Id);
                tt.tt_ManHinh = product.tt_ManHinh;
                tt.tt_Chip = product.tt_Chip;
                tt.tt_BoNho = product.tt_BoNho;
                tt.tt_MauSac = product.tt_MauSac;
                tt.tt_CameraSau = product.tt_CameraSau;
                tt.tt_CameraTruoc = product.tt_CameraTruoc;
                tt.tt_GiaBan = product.tt_GiaBan;
                tt.tt_GiaNhap = product.tt_GiaNhap;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<ProductInfoModel> MoreProduct(string nameProduct)
        {
            var model = from a in db.San_Pham
                        join b in db.Thong_Tin_San_Pham
                        on a.sp_Id equals b.m_SPId
                        where a.sp_Ten != nameProduct
                        select new ProductInfoModel()
                        {
                            sp_Id = a.sp_Id,
                            sp_GiamGia = a.sp_GiamGia,
                            sp_Ten = a.sp_Ten,
                            sp_Anh = a.sp_Anh,
                            sp_GhiChu = a.sp_GhiChu,
                            sp_BaoHanh = a.sp_BaoHanh,
                            tt_Id = b.tt_Id,
                            tt_ManHinh = b.tt_ManHinh,
                            tt_Chip = b.tt_Chip,
                            tt_BoNho = b.tt_BoNho,
                            tt_MauSac = b.tt_MauSac,
                            tt_CameraSau = b.tt_CameraSau,
                            tt_CameraTruoc = b.tt_CameraTruoc,
                            tt_GiaBan = b.tt_GiaBan,
                            tt_GiaNhap = b.tt_GiaNhap
                        };
            return model.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
        }
    }
}
