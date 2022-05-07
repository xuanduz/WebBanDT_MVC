using Model.DbAccessObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDT.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(string nameProduct, string memoryProduct, string colorProduct)
        {
            var product = new ProductInfoDAO().GetProduct(nameProduct, memoryProduct, colorProduct);
            ViewBag.MoreProducts = new ProductInfoDAO().MoreProduct(nameProduct);
            return View(product);
        }
    }
}