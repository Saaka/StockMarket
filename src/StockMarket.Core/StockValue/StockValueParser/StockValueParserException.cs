﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockValue.StockValueParser
{
    public class StockValueParserException : Exception
    {
        public StockValueParserException(string message)
            : base(message)
        {

        }
    }
}
