using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using StockMarket.Core.Logger;
using StockMarket.Core.Configuration;
using StockMarket.Core;

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
                    var stockMarketExecutor = lifetimescope.Resolve<IStockMarketActionExecutor>();

                    try
                    {
                        stockMarketExecutor.RunStockMarket();
                        while (Console.ReadLine() != "quit")
                        {
                            logger.Info("Program terminated");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        Console.WriteLine("Press enter key to exit");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
