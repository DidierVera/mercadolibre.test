using System;
using Autofac;

namespace Mercadolibre.test.Logic.Config
{
    public class ModuleLocator
    {
        private static IContainer container;
        public ModuleLocator()
        {
        }

        public static void ConfigureModules(IContainer modules)
        {
            if (container == null)
            {
                container = modules;
            }
        }

        public static T Resolve<T>()
        {
            if (container == null)
            {
                throw new InvalidOperationException("Autofac is not configured.");
            }

            return container.Resolve<T>();
        }
    }
}
