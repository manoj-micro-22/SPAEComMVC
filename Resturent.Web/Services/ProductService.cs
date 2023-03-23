using Resturent.Web.Models;
using Resturent.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resturent.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceConstant.ApiType.POST,
                Data = productDto,
                Url = ServiceConstant.ProductApiBase + "/add",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceConstant.ApiType.DELETE,
                Url = ServiceConstant.ProductApiBase + "/delete/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceConstant.ApiType.GET,
                Url = ServiceConstant.ProductApiBase + "/products",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceConstant.ApiType.GET,
                Url = ServiceConstant.ProductApiBase + "/product/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceConstant.ApiType.PUT,
                Data = productDto,
                Url = ServiceConstant.ProductApiBase + "/update",
                AccessToken = token
            });
        }
    }
}
