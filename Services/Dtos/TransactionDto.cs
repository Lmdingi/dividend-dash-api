using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Opening { get; set; }
        public decimal OpeningCharges { get; set; }
        public decimal OpeningTotal { get; set; }

        public decimal Closing { get; set; }
        public decimal ClosingCharges { get; set; }
        public decimal ClosingTotal { get; set; }
    }
}
