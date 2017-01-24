using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StockMarket.IoC
{
    public class ConsoleAppContainerBuilder
    {
        public IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            
            builder.RegisterAssemblyTypes(typeof(StockMarket.Core.Configuration.AppConfiguration).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .AsSelf();

            return builder.Build();
        }
    }
}
