using Mango.Frontend.Models;

namespace Mango.Frontend.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDTO requestDTO, bool withBearer = true);
    }
}
