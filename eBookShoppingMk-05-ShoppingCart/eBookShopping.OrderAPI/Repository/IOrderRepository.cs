using eBookShopping.OrderAPI.Models;

namespace eBookShopping.OrderAPI.Repository
{
    public interface IOrderRepository
    {


        Task<bool> AddOrder(OrderHeader header);

        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);

    }
}
