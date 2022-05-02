using eBookShopping.Web.Models;
using System.Threading.Tasks;

namespace eBookShopping.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
        
    }
}
