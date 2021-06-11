using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mercadolibre.test.Logic.Config;
using Mercadolibre.test.Logic.Contract.Presenters;
using Mercadolibre.test.Logic.Models.SharedModels;
using Mercadolibre.test.Logic.Presenter;
using NUnit.Framework;

namespace mercadolibre.test.UnitTest
{
    [TestFixture]
    public class Tests : IGenericView
    {
        private ProductModel prodcutModel;
        private ProductPresenter userPresenter;
        private List<ProductModel> modelResponse;

        private string errorMessage;

        [SetUp]
        public void Setup()
        {
            SetDependencies();

            userPresenter = new ProductPresenter(this);
        }

        [TearDown]
        public void EndTest()
        {
            prodcutModel = null;
            modelResponse = null;
        }

        [Test]
        public async Task Get_ProductsSuccessResponse()
        {
            string filter = "Motorola";
            await userPresenter.GetProductsByFilter(filter);
            Assert.IsNotNull(modelResponse);
        }

        [Test]
        public async Task Get_ProductsFailResponse()
        {
            string filter = ">>__--^[][`";
            await userPresenter.GetProductsByFilter(filter);
            Assert.Zero(modelResponse.Count);
        }

        public void UpdateView(object model)
        {
            modelResponse = (List<ProductModel>)model;
        }

        private void SetDependencies()
        {
            var builder = AutofacConfig.CreateBuilder();
            ModuleLocator.ConfigureModules(builder.Build());
        }

        public void ShowAlert(string message)
        {
            modelResponse = null;
            errorMessage = message;
        }
    }
}
