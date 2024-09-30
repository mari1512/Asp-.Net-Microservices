using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Services.ProductAPI.Data;
using Mongo.Services.ProductAPI.Models;
using Mongo.Services.ProductAPI.Models.DTOs;

namespace Mongo.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private ResponseDto _responseDto;
        private IMapper mapper;

        public ProductController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _responseDto = new ResponseDto();
            this.mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                List<Product> products = _appDbContext.Products.ToList();
                _responseDto.Result = products;
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
                Product products = _appDbContext.Products.First(u=>u.ProductId == id);
                _responseDto.Result = products;
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
        public ResponseDto Post([FromBody] ProductDto dto)
        {
            try
            {
                Product obj = this.mapper.Map<Product>(dto);
                _appDbContext.Products.Add(obj);
                _appDbContext.SaveChanges();

                _responseDto.Result = _appDbContext.Products.First(u => u.ProductId == obj.ProductId);

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
        public ResponseDto Put([FromBody] ProductDto dto)
        {
            try
            {
                Product obj = this.mapper.Map<Product>(dto);
                _appDbContext.Products.Update(obj);
                _appDbContext.SaveChanges();

                _responseDto.Result = _appDbContext.Products.First(u=>u.ProductId == obj.ProductId);


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
                Product product = _appDbContext.Products.FirstOrDefault(u => u.ProductId == id);
                if (product != null)
                {
                    _appDbContext.Products.Remove(product);
                    _appDbContext.SaveChanges();
                }
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
