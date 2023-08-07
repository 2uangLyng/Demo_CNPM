using Demo_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_CNPM.Controllers
{
    public class ShoppingCartController : Controller
    {
        private taphoa_final_demoEntities4 db = new taphoa_final_demoEntities4();
        public ActionResult Showcart()
        {
            if (Session["Cart"] == null)
                return View("EmptyCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var _pro = db.Hàng_Hóa.SingleOrDefault(s => s.ID == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("Proview", "Hàng_Hóa");
        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("Proview", "Hàng_Hóa");
        }
        public PartialViewResult BagCart()
        {
            int total_quantity_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_quantity_item = cart.Total_quantity();
            ViewBag.QuantityCart = total_quantity_item;
            return PartialView("BagCart");
        }
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["CartQuantity"]);
            cart.Update_quantity(id_pro, _quantity);
            return RedirectToAction("Proview", "Hàng_Hóa");
        }


        public ActionResult CheckOut(FormCollection from)
        {

            Cart cart = Session["Cart"] as Cart;
            var user = (Demo_CNPM.Models.Nhân_viên)HttpContext.Session["user"];
            var user2 = user.ID;

            // Tạo hóa đơn mới (_order) và lưu vào cơ sở dữ liệu
            Hóa_đơn _order = new Hóa_đơn();
            _order.Ngày_bán = DateTime.Now;
            _order.ID_NV = user2;
                db.Hóa_đơn.Add(_order);

            foreach (var item in cart.Items)
            {
                Chi_tiết_hóa_đơn _oder_detail = new Chi_tiết_hóa_đơn();
                
                // Gán ID_HD cho _oder_detail sau khi _order đã có ID mới
                _oder_detail.ID_HD = _order.ID;
                _oder_detail.ID_HH = item._product.ID;
                _oder_detail.SL = item._quantity;
                _oder_detail.Đơn_giá = item._product.Giá_bán;
                _oder_detail.Thành_tiền = item._quantity * item._product.Giá_bán;
                db.Chi_tiết_hóa_đơn.Add(_oder_detail);

                foreach (var p in db.Hàng_Hóa.Where(s => s.ID == _oder_detail.ID_HH))
                {
                    // Lưu trữ thông tin Hàng Hóa (_product)
                    var update_quan_pro = p.SL_ton - item._quantity;
                    p.SL_ton = update_quan_pro;
                }
            }
            db.SaveChanges();
            cart.ClearCart();
            return RedirectToAction("CheckOut_Success", "ShoppingCart");
        }

        public ActionResult CheckOut_Success()
        {
            return View();
        }
    }
}

    
