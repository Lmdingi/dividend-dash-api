using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Totals
    {
        public List<decimal> Portfolio { get; set; }
        public List<decimal> Commission { get; set; }
        public List<decimal> Profit { get; set; }
    }
}
