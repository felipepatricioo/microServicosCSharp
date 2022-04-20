using AutoMapper;
using eBookShopping.CartAPI.Data.ValueObjects;
using eBookShopping.CartAPI.Models;

namespace eBookShopping.CartAPI.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product >();
                config.CreateMap<Product, ProductVO>();
                config.CreateMap<CartVO, Cart >();
                config.CreateMap<Cart, CartVO>();
                config.CreateMap<CartHeader, CartHeaderVO>();
                config.CreateMap<CartHeaderVO, CartHeader>();
                config.CreateMap<CartDetail, CartDetailVO>();
                config.CreateMap<CartDetailVO, CartDetail>();
            });


            return mappingConfig;
        }

    }
}
