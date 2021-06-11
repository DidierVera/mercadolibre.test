using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercadolibre.test.Logic.Config;
using Mercadolibre.test.Logic.Contract.Presenters;
using Mercadolibre.test.Logic.Contract.Services;
using Mercadolibre.test.Logic.Models.SharedModels;

namespace Mercadolibre.test.Logic.Presenter
{
    public class ProductPresenter
    {
        private readonly IGenericView _genericView;
        private readonly IProductsService _productsService;
        public ProductPresenter(IGenericView userView)
        {
            _genericView = userView;
            _productsService = ModuleLocator.Resolve<IProductsService>();
        }

        public async Task GetProductsByFilter(string filter)
        {
            try
            {
                List<ProductModel> data = new List<ProductModel>();

                var serviceResult = await _productsService.FindProducts(filter);
                if (serviceResult != null && serviceResult.results.Count > 0)
                {
                    data = serviceResult.results.Select(x => new ProductModel
                    {
                        Price = x.price,
                        ProductName = x.title,
                        City = x.address.city_name,
                        State = x.address.state_name,
                        FreeShipping = x.shipping.free_shipping ? "Envío gratis" : ""
                    }).ToList();
                }
                _genericView.UpdateView(data);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
