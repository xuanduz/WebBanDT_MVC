using Model.DbAccessObj;
using WebDT.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;

namespace WebDT.Areas.Admin.Controllers
{
    public class AdminListProductController : BaseController
    {
        // GET: Admin/AdminListProduct
        [HttpGet]
        public ActionResult Index()
        {
            var res = new UserDAO().GetInfoProductForAdmin();
            return View(res);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var res = new ProductInfoDAO().GetProduct(id);
            return View(res);
        }

        [HttpPost]
        public ActionResult Edit(ProductInfoModel product)
        {
            if (ModelState.IsValid)
            {
                var res = new ProductInfoDAO().UpdateProduct(product);
                if (res)
                {
                    return RedirectToAction("Index", "AdminListProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                }
            }
            else
            {
                ModelState.AddModelError("", "Sai kiểu");
            }
            return View("Index");
        }
    }
}