using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core
{
    public class StockValue
    {
        public StockValue(string name, decimal value, DateTime date)
        {
            Name = name;
            Value = value;
            Date = date;
        }

        public string Name { get; }
        public DateTime Date { get; }
        public decimal Value { get; }
    }
}
