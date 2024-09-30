using Mango.Services.CartApi.Models.Dtos;

namespace Mango.Services.CartApi.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }

}
