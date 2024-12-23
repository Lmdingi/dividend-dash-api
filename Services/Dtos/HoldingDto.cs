using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class HoldingDto
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required, Length(3,3)]
        public string? Symbol { get; set; }
        public TransactionDto? Transaction { get; set; }
        public SummaryDto? Summary { get; set; }
    }
}
