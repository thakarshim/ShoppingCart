using System;
using System.Collections.Generic;

namespace ShoppingCart.Domain
{
    public interface ICart
    {
        List<CartItem> CartItems { get; set; }
        Double TotalPrice { get; set; }
        Double TotalDiscountApplied { get; set; }
        Double GrandTotal { get; set; }
        void CalculatePrice();
    }
}
