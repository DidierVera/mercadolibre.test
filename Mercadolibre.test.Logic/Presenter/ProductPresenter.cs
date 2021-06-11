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
                        ProductName = x.title,
                        Price = x.price,
                        FreeShipping = x.shipping.free_shipping ? "Envío gratis" : "",
                        City = x.address.city_name,
                        State = x.address.state_name,
                        Condition = x.attributes.FirstOrDefault(x=> x.id == "ITEM_CONDITION").value_name,
                        ImageUrl = x.thumbnail,
                        SoldQuantity = x.sold_quantity,
                        Installments = x.installments != null ? new InstallmentsModel
                        {
                            Amount = x.installments.amount,
                            Quantity = x.installments.quantity,
                            Rate = x.installments.rate
                        } : null

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
