using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid HoldingId { get; set; }
        public Holding? Holding { get; set; }
        public decimal Opening { get; set; }
        public decimal OpeningCharges { get; set; }
        public decimal OpeningTotal { get; set; }

        public decimal Closing { get; set; }
        public decimal ClosingCharges { get; set; }
        public decimal ClosingTotal { get; set; }
    }
}
