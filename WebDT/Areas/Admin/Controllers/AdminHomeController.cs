using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DbAccessObj;

namespace WebDT.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        // GET: Admin/AdminHome
        [HttpGet]
        public ActionResult Index()
        {
            var res = new UserDAO().TotalSalesToday();
            return View(res);
        }

        [ChildActionOnly]
        public PartialViewResult Table()
        {
            string year = DateTime.Now.Year.ToString();
            string year2 = "2021";
            var res = new UserDAO().GetChart(year2);
            return PartialView(res);
            //return PartialView();
        }
    }
}