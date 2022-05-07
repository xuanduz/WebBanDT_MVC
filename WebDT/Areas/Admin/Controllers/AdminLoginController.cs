using Model.DbAccessObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Areas.Admin.Models;
using WebDT.Common;

namespace WebDT.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var DAO = new UserDAO();
                var res = DAO.Login(model.UserName, model.Password);
                if (res == 1)
                {
                    var user = DAO.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.ad_UserName;
                    userSession.UserId = user.ad_Id;
                    userSession.FullName = user.ad_HoVaTen;

                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "AdminHome");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");

                }
            }
            return View("Index");
        }

        public PartialViewResult AdminName()
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            return PartialView(session);
        }
    }
}