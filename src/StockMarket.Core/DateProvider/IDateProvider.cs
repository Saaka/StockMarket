using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.DateProvider
{
    public interface IDateProvider
    {
        DateTime GetCurrentDateTime();
    }
}
