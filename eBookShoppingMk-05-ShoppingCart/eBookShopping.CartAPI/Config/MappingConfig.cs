using AutoMapper;
using eBookShopping.CartAPI.Models;

namespace eBookShopping.CartAPI.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<ProductVO, Product >();
                //config.CreateMap<Product, ProductVO>();
            });


            return mappingConfig;
        }

    }
}
