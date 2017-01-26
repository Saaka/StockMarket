using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockValue
{
    public class StockValue
    {
        public StockValue(string name, decimal value, DateTime date)
        {
            Name = name;
            Value = value;
            Date = date;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
