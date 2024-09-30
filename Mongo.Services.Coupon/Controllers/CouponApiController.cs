using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Services.CartApi.Data;
using Mongo.Services.CartApi.Models;
using Mongo.Services.CartApi.Models.DTOs;

namespace Mongo.Services.CartApi.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponApiController : ControllerBase
    {
        private AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper mapper;

        public CouponApiController(AppDbContext db,IMapper map)
        {
            _db = db;
            _responseDto = new ResponseDto();
            mapper = map;
        }

        [HttpGet]

        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Models.Coupon> obj = _db.Coupons.ToList();
                _responseDto.Result = mapper.Map< IEnumerable<CouponDto>>(obj);
                

            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]

        public ResponseDto Get(int id)
        {
            try
            {
                Models.Coupon coupon = _db.Coupons.First(c => c.CouponId == id);
                _responseDto.Result = mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Models.Coupon obj = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                _responseDto.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Models.Coupon obj = mapper.Map<Models.Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Models.Coupon obj = mapper.Map<Models.Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _responseDto.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Models.Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();


            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

    }
}
