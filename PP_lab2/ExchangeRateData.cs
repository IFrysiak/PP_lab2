using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_lab2
{
    public class ExchangeRateData
    {
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }

        public override string ToString()
        {
            string ratesStr = string.Join("\n", Rates.Select(rate => $"{rate.Key}: {rate.Value}"));
            return $"Date: {Program.date}\nBase currency: {Base}\nExchange rates:\n{ratesStr}";
        }
    }
}
