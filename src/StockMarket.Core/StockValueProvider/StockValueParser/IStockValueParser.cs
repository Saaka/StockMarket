﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockValueProvider.StockValueParser
{
    public interface IStockValueParser
    {
        decimal GetParsedValue(string data);
    }
}
