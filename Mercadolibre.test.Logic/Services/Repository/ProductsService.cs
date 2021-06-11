using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mercadolibre.test.Logic.Contract.Services;
using Mercadolibre.test.Logic.Models.ServicesModel;

namespace Mercadolibre.test.Logic.Services.Repository
{
    public class ProductsService : IProductsService
    {
        private readonly MainApiClient _client;
        public ProductsService()
        {
            _client = new MainApiClient();
        }

        public async Task<ResponseModel> FindProducts(string queryString)
        {
            return await _client.GetAsync<string, ResponseModel>(queryString);
        }
    }
}
