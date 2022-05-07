using Model.DbAccessObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Models.EF;

namespace WebDT.Areas.Admin.Controllers
{
    public class AdminNCCController : BaseController
    {
        // GET: Admin/AdminNCC
        [HttpGet]
        public ActionResult Index()
        {
            var res = new UserDAO().GetNCC();
            return View(res);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var ncc = new UserDAO().ViewDetailNCC(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Detail(Nha_Cung_Cap ncc)
        {
            if (ModelState.IsValid)
            {
                var DAO = new UserDAO();
                var res = DAO.UpdateNCC(ncc);
                if (res)
                {
                    return RedirectToAction("Index", "AdminNCC");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                }
            }
            return View("Index");
        }
    }
}