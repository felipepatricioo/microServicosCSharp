using AutoMapper;
using eBookShopping.CartAPI.Data.ValueObjects;
using eBookShopping.CouponAPI.Models;

namespace eBookShopping.CouponAPI.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
                config.CreateMap<Coupon, CouponVO>().ReverseMap();
            });


            return mappingConfig;
        }

    }
}
