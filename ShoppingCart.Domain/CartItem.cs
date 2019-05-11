using System;
using System.Collections.Generic;

namespace ShoppingCart.Domain
{
    public class CartItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; }
        public Coupon Coupon { get; set; }
    }

    public class Cart : ICart
    {
        public List<CartItem> CartItems { get; set; }
        public Double TotalPrice { get; set; }
        public Double TotalDiscountApplied { get; set; }
        public Double GrandTotal { get; set; }

        public void CalculatePrice()
        {
            foreach (var item in this.CartItems)
            {
                var itemTotalPrice = item.Price * item.Quantity;
                TotalPrice = TotalPrice + itemTotalPrice;

                if (item.Coupon != null)
                {
                    Double discount = 0;
                    switch (item.Coupon.Type)
                    {
                        case CouponType.BuyTwoGetOneFree:
                            if (item.Quantity == 1)
                            {
                                discount = 0;
                            }
                            else if (item.Quantity == 2)
                            {
                                discount = item.Price;
                            }
                            else if (item.Quantity > 2)
                            {
                                for (int i = 2; i <= item.Quantity; i += 2)
                                {
                                    discount = discount + item.Price;
                                }
                            }
                            break;
                        case CouponType.TenPercentFlatDiscount:
                            discount = ((item.Price * 10) / 100);
                            break;
                    }
                    TotalDiscountApplied = TotalDiscountApplied + discount;
                }
                GrandTotal = TotalPrice - TotalDiscountApplied;
            }
        }
        private Cart()
        {
            this.CartItems = new List<CartItem>();
            this.TotalDiscountApplied = 0;
            this.GrandTotal = 0;
            this.TotalPrice = 0;
        }

        public Cart(List<CartItem> items)
        {
            this.CartItems = items;
            this.TotalDiscountApplied = 0;
            this.GrandTotal = 0;
            this.TotalPrice = 0;
        }
    }
}
