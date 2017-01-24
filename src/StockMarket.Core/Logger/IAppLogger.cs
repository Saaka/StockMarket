using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.Logger
{
    public interface IAppLogger
    {
        void Info(string info);
        void Error(string error);
        void Warning(string warning);
    }
}
