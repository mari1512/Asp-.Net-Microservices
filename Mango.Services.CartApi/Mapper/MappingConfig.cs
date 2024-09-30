using AutoMapper;
using Mango.Services.CartApi.Models;
using Mango.Services.CartApi.Models.Dtos;

namespace Mango.Services.CartApi.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration MapConfig()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });

            return mappingConfig;


        }
    }
}
