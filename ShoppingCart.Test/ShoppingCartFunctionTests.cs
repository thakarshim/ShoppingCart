using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Domain;
using System.Collections.Generic;

namespace ShoppingCart.Test
{
    [TestClass]
    public class ShoppingCartFunctionTests
    {
        [TestMethod]
        public void Buy_One_Get_One_Free_Discount()
        {
            Coupon buyTwoGetOneFree = new Coupon
            {
                CouponId = 1,
                Description = "Buy Two get one free",
                Type = CouponType.BuyTwoGetOneFree
            };

            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem {ItemId=1 , Name = "Baby shampoo", Description= "Baby shampppo for babies less than 3 years", Price =100, Quantity=3, Coupon =  buyTwoGetOneFree },
            };

            double totalPriceShouldBe = 300;
            double totalDiscountShouldBe = 100;
            double grandTotalShouldBe = 200;

            ICart shoppingCart = new Cart(cartItems);
            shoppingCart.CalculatePrice();

            Assert.AreEqual(totalPriceShouldBe, shoppingCart.TotalPrice);
            Assert.AreNotEqual(0, shoppingCart.TotalPrice);
            Assert.AreEqual(totalDiscountShouldBe, shoppingCart.TotalDiscountApplied);
            Assert.AreNotEqual(0, shoppingCart.TotalDiscountApplied);
            Assert.AreEqual(grandTotalShouldBe, shoppingCart.GrandTotal);
            Assert.AreNotEqual(0, shoppingCart.GrandTotal);
            Assert.AreNotEqual(shoppingCart.TotalPrice, shoppingCart.GrandTotal);
        }

        [TestMethod]
        public void No_Discount_Applied()
        {
          
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem {ItemId=1 , Name = "Ceralac", Description= "Baby Powder less than 3 years", Price =78, Quantity=2, Coupon =  null },
                new CartItem {ItemId=2 , Name = "Tomato Cathup", Description= "A rotten tomato catchup", Price =100, Quantity=1, Coupon =  null }
            };

            double totalPriceShouldBe = 256;
            double totalDiscountShouldBe = 0;
            double grandTotalShouldBe = 256;

            ICart shoppingCart = new Cart(cartItems);
            shoppingCart.CalculatePrice();

            Assert.AreEqual(totalPriceShouldBe, shoppingCart.TotalPrice);
            Assert.AreEqual(totalDiscountShouldBe, shoppingCart.TotalDiscountApplied);
            Assert.AreEqual(grandTotalShouldBe, shoppingCart.GrandTotal);
            Assert.AreEqual(shoppingCart.TotalPrice, shoppingCart.GrandTotal);

        }

        [TestMethod]
        public void Flat_Discount_Applied()
        {
            Coupon tenPercentDiscountCoupon = new Coupon
            {
                CouponId = 2,
                Description = "Ten percent flat discount",
                Type = CouponType.TenPercentFlatDiscount
            };

            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem {ItemId=1 , Name = "Ceralac", Description= "Baby Powder less than 3 years", Price =200, Quantity=2, Coupon =  tenPercentDiscountCoupon },
                new CartItem {ItemId=3 , Name = "Tomato Cathup", Description= "A rotten tomato catchup", Price =150, Quantity=1, Coupon =  tenPercentDiscountCoupon }
            };

            double totalPriceShouldBe = 550;
            double totalDiscountShouldBe = 35;
            double grandTotalShouldBe = 515;

            ICart shoppingCart = new Cart(cartItems);
            shoppingCart.CalculatePrice();

            Assert.AreEqual(totalPriceShouldBe, shoppingCart.TotalPrice);
            Assert.AreNotEqual(0, shoppingCart.TotalPrice);
            Assert.AreEqual(totalDiscountShouldBe, shoppingCart.TotalDiscountApplied);
            Assert.AreNotEqual(0, shoppingCart.TotalDiscountApplied);
            Assert.AreEqual(grandTotalShouldBe, shoppingCart.GrandTotal);
            Assert.AreNotEqual(shoppingCart.TotalPrice, shoppingCart.GrandTotal);
        }
    }
}
