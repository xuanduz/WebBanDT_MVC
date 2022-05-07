using Model.DbAccessObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Common;
using WebDT.Models;
using WebDT.Models.EF;

namespace WebDT.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.nd_UserName))
                {
                    ModelState.AddModelError("", "Ten dang nhap da ton tai");
                }else if (dao.CheckEmail(model.nd_Email))
                {
                    ModelState.AddModelError("", "Email da ton tai");
                }
                else
                {
                    var user = new Nguoi_Dung();
                    user.nd_HoVaTen = model.nd_HoVaTen;
                    user.nd_UserName = model.nd_UserName;
                    user.nd_Password = model.nd_Password;
                    user.nd_Email = model.nd_Email;
                    user.nd_DiaChi = model.nd_DiaChi;
                    user.nd_SoDienThoai = model.nd_SoDienThoai;

                    var res = dao.InsertClient(user);
                    if(res > 0)
                    {
                        ViewBag.Success = "Dang ky thanh cong";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Dang ky khong thanh cong");
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var DAO = new UserDAO();
                var res = DAO.LoginClient(model.UserName, model.Password);
                if (res == 1)
                {
                    var user = DAO.GetByUserNameClient(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.nd_UserName;
                    userSession.UserId = user.nd_Id;
                    userSession.FullName = user.nd_HoVaTen;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return Redirect("/");
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
            return View(model);
        }
        [HttpGet]
        public PartialViewResult Account()
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            return PartialView(session);
        }
        [HttpGet]
        public ActionResult Detail()
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            var user = new UserDAO().ViewDetailUser(session.UserName);
            return View(user);
        }
        [HttpPost]
        public ActionResult Detail(Nguoi_Dung user)
        {
            if (ModelState.IsValid)
            {
                var DAO = new UserDAO();
                var res = DAO.UpdateUser(user);
                if (res)
                {
                    return RedirectToAction("Detail", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật khong thành công");
                }
            }
            return View(user);
        }

    }
}