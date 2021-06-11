using System;
namespace Mercadolibre.test.Logic.Models.SharedModels
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FreeShipping { get; set; }
        public string SellerName { get; set; }
        public double SoldQuantity { get; set; }
        public string Condition { get; set; }
        public string ImageUrl { get; set; }
        public InstallmentsModel Installments { get; set; }
    }
}
