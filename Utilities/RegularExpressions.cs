using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAP.Utilities
{
    public class RegularExpressions
    {
        public static Regex InvoiceTotalsRegex()
        {
            return new Regex(@"(?<=Total  +)-?(?:0|[1-9]\d{0,2}(?:,?\d{3})*)(?:\.\d+)?");
        }

        public static Regex RegexMonthlyContributionAndNetPayLine()
        {
            return new Regex(@"(?<=Net Pay  +)-?(?:0|[1-9]\d{0,2}(?:,?\d{3})*)(?:\.\d+)?");
        }
    }
}
