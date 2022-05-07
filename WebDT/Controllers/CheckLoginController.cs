using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Common;

namespace WebDT.Controllers
{
    public class CheckLoginController : Controller
    {
        // GET: CheckLogin
        [HttpGet]
        public ActionResult DeleteSession()
        {
            Session.Remove(CommonConstant.USER_SESSION);
            return Redirect("/");
        }
        public ActionResult CheckSession()
        {
            if(Session[(CommonConstant.USER_SESSION)] != null)
            {
                return Redirect("/cart/payment");
            }
            return Redirect("/User/Login");
        }
    }
}