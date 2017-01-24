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

            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterAssemblyTypes(typeof(Core.Logger.NLogAppLogger).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .AsSelf();

            return builder.Build();
        }
    }
}
