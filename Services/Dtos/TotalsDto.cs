using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class TotalsDto
    {
        public decimal Portfolio { get; set; }
        public decimal OpeningCommission { get; set; }
        public decimal IncomeCommission { get; set; }
        public decimal Net { get; set; }
        public decimal Profit { get; set; }
        public int AllHoldingsCount { get; set; }
    }
}
