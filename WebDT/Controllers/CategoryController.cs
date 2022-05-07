using Model.DbAccessObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace WebDT.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string searchCategory, int page = 1, int pageSize = 20)
        {
            var res = new ProductInfoDAO().ListAllProductPaging(searchCategory, page, pageSize);
            return View(res);
        }

    }
}