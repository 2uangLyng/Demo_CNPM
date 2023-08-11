using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_CNPM.Models
{
    public class CartItem
    {
        public Hàng_Hóa _product { get; set; }
        public int _quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add_Product_Cart(Hàng_Hóa _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ID == _pro.ID);
            if (item == null)
                items.Add(new CartItem
                {
                    _product = _pro,
                    _quantity = _quan

                });
            else
                item._quantity += _quan;
        }
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }
        public int Total_money()
        {
            var total = items.Sum(s => s._quantity * s._product.Giá_bán);
            return total;
        }
        public void Update_quantity(int id, int _new_quan)
        {
            var item = items.Find(s => s._product.ID == id);
            if (items != null)
            {

                item._quantity = _new_quan;
            }
        }

        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._product.ID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}
