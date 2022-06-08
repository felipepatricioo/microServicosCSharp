using eBookShopping.Email.Messages;
using System.Threading.Tasks;

namespace eBookShopping.Email.Repository
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
