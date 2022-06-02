

using eBookShopping.CartAPI.Data.ValueObjects;

namespace eBookShopping.CartAPI.Repository
{
    public interface ICouponRepository
    {

        Task<CouponVO> GetCoupon(string couponCode, string token);


    }
}
