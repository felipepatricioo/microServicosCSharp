using eBookShopping.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBookShopping.Web.Services.IServices
{
    public interface IProductService
    {

        Task<IEnumerable<ProductModel>> FindAllProducts(string token);

        Task<ProductModel> FindProductById(long id, string token);

        Task<ProductModel> Create(ProductModel model, string token);

        Task<ProductModel> Update(ProductModel model, string token);

        Task<bool> DeleteProductById(long id, string token);

    }
}
