using Mongo.Services.CartApi.Models.DTOs;

namespace Mango.Services.CartApi.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
