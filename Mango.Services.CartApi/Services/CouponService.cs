using Mango.Services.CartApi.Models.Dtos;
using Mango.Services.CartApi.Services.IServices;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Mongo.Services.CartApi.Models.DTOs;
using Newtonsoft.Json;

namespace Mango.Services.CartApi.Services
{
    public class CouponService:ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
            var apicontent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apicontent);
            if (resp != null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Result));
            }
            return new CouponDto();
        }
    }
}
