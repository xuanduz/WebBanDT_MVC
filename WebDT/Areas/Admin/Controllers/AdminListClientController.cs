using Model.DbAccessObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Models.EF;

namespace WebDT.Areas.Admin.Controllers
{
    public class AdminListClientController : BaseController
    {
        [HttpGet]
        // GET: Admin/AdminListClient
        public ActionResult Index()
        {
            var Clients = new UserDAO().GetAllClient();
            return View(Clients);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var client = new UserDAO().ViewDetailUser(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Nguoi_Dung client)
        {
            if (ModelState.IsValid)
            {
                var DAO = new UserDAO();
                var res = DAO.UpdateUser(client);
                if (res)
                {
                    return RedirectToAction("Index", "AdminListClient");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}