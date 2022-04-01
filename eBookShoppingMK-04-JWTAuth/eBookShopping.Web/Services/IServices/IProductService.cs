using eBookShopping.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBookShopping.Web.Services.IServices
{
    public interface IProductService
    {

        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long id);

        Task<ProductModel> Create(ProductModel model);

        Task<ProductModel> Update(ProductModel model);

        Task<bool> DeleteProductById(long id);

    }
}
