using System;
using Autofac;
using Mercadolibre.test.Logic.Contract.Services;
using Mercadolibre.test.Logic.Services.Repository;

namespace Mercadolibre.test.Logic.Config
{
    public  static class AutofacConfig
    {

        public static ContainerBuilder CreateBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            return builder;
        }

        private class ServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ProductsService>().As<IProductsService>();
            }
        }
    }
}
