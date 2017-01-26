using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StockMarket.Core.Logger
{
    public class NLogAppLogger : IAppLogger
    {
        private readonly NLog.Logger logger;

        public NLogAppLogger()
        {
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "NLog.config")))
                CreateDefaultConfig();

            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Error(string error)
        {
            logger.Error(error);
        }

        public void Error(Exception exception)
        {
            logger.Error(exception);
        }

        public void Info(string info)
        {
            logger.Info(info);
        }

        public void Warning(string warning)
        {
            logger.Warn(warning);
        }

        private void CreateDefaultConfig()
        {
            var config = new LoggingConfiguration();
            var target = new ConsoleTarget
            {
                Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss} ${level}: ${message}"
            };
            var rule = new LoggingRule("*", NLog.LogLevel.Info, target);

            config.AddTarget("console", target);
            config.LoggingRules.Add(rule);

            NLog.LogManager.Configuration = config;
        }
    }
}
