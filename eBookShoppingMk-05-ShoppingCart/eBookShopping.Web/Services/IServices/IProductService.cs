using eBookShopping.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBookShopping.Web.Services.IServices
{
    public interface IProductService
    {

        Task<IEnumerable<ProductViewModel>> FindAllProducts(string token);

        Task<ProductViewModel> FindProductById(long id, string token);

        Task<ProductViewModel> Create(ProductViewModel model, string token);

        Task<ProductViewModel> Update(ProductViewModel model, string token);

        Task<bool> DeleteProductById(long id, string token);

    }
}
