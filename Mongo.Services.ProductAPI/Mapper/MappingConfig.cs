using AutoMapper;
using Mongo.Services.ProductAPI.Models;
using Mongo.Services.ProductAPI.Models.DTOs;

namespace Mongo.Services.ProductAPI.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration MapConfig()
        {
            var mapConfig = new MapperConfiguration(config => {
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<ProductDto, Product>();
            });

            return mapConfig;


        }
    }
}
