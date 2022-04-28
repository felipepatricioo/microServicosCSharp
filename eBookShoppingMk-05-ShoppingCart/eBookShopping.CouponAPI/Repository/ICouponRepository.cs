using eBookShopping.CouponAPI.Data.ValueObjects;

namespace eBookShopping.CouponAPI.Repository
{
    public interface ICouponRepository
    {

        Task<CouponVO> GetCouponByCouponCode(string couponCode);


    }
}
