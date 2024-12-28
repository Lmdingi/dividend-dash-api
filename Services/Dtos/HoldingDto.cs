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
        [Required, RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "The Name field can only contain letters.")]
        public string? Name { get; set; }
        [Required, Length(3,3, ErrorMessage = "The Symbol field can only contain 3 letters."), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Symbol field can only contain letters.")]
        public string? Symbol { get; set; }
        public TransactionDto? Transaction { get; set; }
        public SummaryDto? Summary { get; set; }
    }
}
