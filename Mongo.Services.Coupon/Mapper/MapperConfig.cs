using AutoMapper;
using Mongo.Services.CartApi.Models;
using Mongo.Services.CartApi.Models.DTOs;

namespace Mongo.Services.CartApi.Mapper
{
    public class MapperConfig
    {
        public static MapperConfiguration MapConfig()
        {
            var mapConfig = new MapperConfiguration(config =>{
                config.CreateMap<Models.Coupon,CouponDto>();
                config.CreateMap<CouponDto, Models.Coupon>();
            });

            return mapConfig;


        }
    }
}
