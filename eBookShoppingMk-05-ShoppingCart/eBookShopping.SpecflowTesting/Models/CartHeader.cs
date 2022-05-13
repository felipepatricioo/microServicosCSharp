
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookShopping.SpecflowTesting.Model
{
    [Table("cart_header")]
    public class CartHeader 
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("coupon_code")]
        public string? CouponCode { get; set; }

    }
}
