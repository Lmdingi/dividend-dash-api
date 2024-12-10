using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class HoldingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public TransactionDto? Transaction { get; set; }
        public SummaryDto? Summary { get; set; }
    }
}
