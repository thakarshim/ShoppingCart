namespace ShoppingCart.Domain
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Description { get; set; }
        public CouponType Type { get; set; }
    }
}
