using System;
using System.Threading.Tasks;
using Mercadolibre.test.Logic.Models.ServicesModel;

namespace Mercadolibre.test.Logic.Contract.Services
{
    public interface IProductsService
    {
        public Task<ResponseModel> FindProducts(string queryString);
    }
}
