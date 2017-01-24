using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using StockMarket.Core.Logger;
using StockMarket.Core.Configuration;

namespace StockMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Type 'quit' to exit");
            using (var container = new IoC.ConsoleAppContainerBuilder().BuildContainer())
            {
                using (var lifetimescope = container.BeginLifetimeScope())
                {
                    var logger = lifetimescope.Resolve<IAppLogger>();
                    var config = lifetimescope.Resolve<IAppConfigurationProvider>();

                    logger.Info(config.GetConfiguration().Interval.ToString());
                    while (Console.ReadLine() != "quit")
                    {
                        logger.Info(config.GetConfiguration().Interval.ToString());
                    }
                }
            }            
        }
    }
}
