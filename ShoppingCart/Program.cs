using ShoppingCart.Domain;
using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Coupon buyTwoGetOneFree = new Coupon
            {
                CouponId = 1,
                Description = "Buy Two get one free",
                Type = CouponType.BuyTwoGetOneFree
            };

            Coupon tenPercentDiscountCoupon = new Coupon
            {
                CouponId = 2,
                Description = "Ten percent flat discount",
                Type = CouponType.TenPercentFlatDiscount
            };

            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem {ItemId=1 , Name = "Baby shampoo", Description= "Baby shampppo for babies less than 3 years", Price =100, Quantity=3, Coupon =  buyTwoGetOneFree },
                new CartItem {ItemId=2 , Name = "Baby Telcom Powder", Description= "Baby Powder less than 3 years", Price =150, Quantity=1, Coupon =  tenPercentDiscountCoupon },
                new CartItem {ItemId=3 , Name = "Ceralac", Description= "Baby Powder less than 3 years", Price =78, Quantity=2, Coupon =  null }
            };

            ICart cart = new Cart(cartItems);
            cart.CalculatePrice();
            Console.WriteLine("Total price" + cart.TotalPrice);
            Console.WriteLine("Total Discount Applied" + cart.TotalDiscountApplied);
            Console.WriteLine("Grand total" + cart.GrandTotal);
            Console.ReadLine();
        }
    }
}
