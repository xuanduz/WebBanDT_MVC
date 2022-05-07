using Model.DbAccessObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDT.Areas.Admin.Controllers
{
    public class AdminOrdersController : BaseController
    {
        // GET: Admin/AdminOrders
        [HttpGet]
        public ActionResult Index()
        {
            var res = new UserDAO().GetOrders();
            return View(res);
        }
    }
}