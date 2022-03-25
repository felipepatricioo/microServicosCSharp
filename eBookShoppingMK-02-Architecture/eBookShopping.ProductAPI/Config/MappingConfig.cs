using AutoMapper;
using eBookShopping.ProductAPI.Data.ValueObjects;
using eBookShopping.ProductAPI.Models;

namespace eBookShopping.ProductAPI.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product >();
                config.CreateMap<Product, ProductVO>();
            });


            return mappingConfig;
        }

    }
}
