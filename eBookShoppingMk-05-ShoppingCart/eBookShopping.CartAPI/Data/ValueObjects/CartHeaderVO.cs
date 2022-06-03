using eBookShopping.CartAPI.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookShopping.CartAPI.Data.ValueObjects
{
    public class CartHeaderVO
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}