using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.Logger
{
    public interface IAppLogger
    {
        void Info(string info);
        void Warning(string warning);
        void Error(string error);
        void Error(Exception exception);
    }
}
