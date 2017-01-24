using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.Configuration
{
    public interface IAppConfigurationProvider
    {
        IAppConfiguration GetConfiguration();
    }
}
