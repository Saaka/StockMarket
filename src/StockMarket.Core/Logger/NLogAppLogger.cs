using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.Logger
{
    public class NLogAppLogger : IAppLogger
    {
        private readonly NLog.Logger logger;

        public NLogAppLogger()
        {
            var config = NLog.LogManager.Configuration;
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Error(string error)
        {
            logger.Error(error);
        }

        public void Error(Exception exception)
        {
            logger.Error(exception.Message);
        }

        public void Info(string info)
        {
            logger.Info(info);
        }

        public void Warning(string warning)
        {
            logger.Warn(warning);
        }
    }
}
