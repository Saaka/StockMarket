using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using StockMarket.Core.Logger;

namespace StockMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var container = new IoC.ConsoleAppContainerBuilder().BuildContainer())
            {
                using (var lifetimescope = container.BeginLifetimeScope())
                {
                    var logger = lifetimescope.Resolve<IAppLogger>();

                    logger.Info("First info");
                }
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
