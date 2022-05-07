using Model.DbAccessObj;
using WebDT.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebDT.Common;
using WebDT.Models;

namespace WebDT.Controllers
{
    public class CartController : Controller
    {
        //private string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(int spId, int quantity)
        {
            var product = new ProductInfoDAO().GetProduct(spId);
            var cart = Session[CommonConstant.CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x => x.Product.tt_Id == spId))
                {
                    foreach(var item in list)
                    {
                        if(item.Product.tt_Id == spId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // tao moi doi tuong cartitem
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //gan vao session
                Session[CommonConstant.CartSession] = list;
            }
            else
            {
                // tao moi doi tuong cartitem
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao session
                Session[CommonConstant.CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.tt_Id == item.Product.tt_Id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                    if (jsonItem.Quantity == 0)
                    {
                        Delete(item.Product.tt_Id);
                        sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];
                        break;
                    }
                }
                
            }
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];
            sessionCart.RemoveAll(x => x.Product.tt_Id == id);
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Payment()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            foreach(CartItem item in list)
            {
                var tt_idsp = item.Product.tt_Id;
                var sl = item.Quantity;

                Dat_Hang dh = new WebDT.Models.EF.Dat_Hang();

                dh.dh_NgayDat = DateTime.Today;
                dh.dh_HinhThuc = "Online";
                dh.dh_TrangThai = "Delivering";

                var session = (UserLogin)Session[CommonConstant.USER_SESSION];
                var user = new CartDAO().GetIdUser(session.UserName);
                dh.dh_ndId = user.nd_Id;

                var dh_id = new CartDAO().Insert(dh);

                Dat_Hang_San_Pham dhsp = new Dat_Hang_San_Pham();
                dhsp.dhsp_spId = tt_idsp;
                dhsp.dhsp_dhId = dh.dh_Id;
                dhsp.dhsp_SoLuong = item.Quantity;

                var check = new CartDAO().InsertDHSP(dhsp);
            }
            return View(list);
        }

    }
}