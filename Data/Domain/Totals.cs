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
        public List<decimal> OpeningCommission { get; set; }
        public List<decimal> DivCommission { get; set; }
        public List<decimal> ClosingCommission { get; set; }
        public List<decimal> Net { get; set; }
        public List<decimal> Profit { get; set; }
        public int AllHoldingsCount { get; set; }
    }
}