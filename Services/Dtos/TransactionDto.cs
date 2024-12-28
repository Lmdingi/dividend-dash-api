using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "The Opening value must be 0 or greater.")]
        public decimal Opening { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "The Opening Commission value must be 0 or greater.")]
        public decimal OpeningCharges { get; set; }
        public decimal OpeningTotal { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The Closing value must be 0 or greater.")]
        public decimal Closing { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The Closing Commission value must be 0 or greater.")]
        public decimal ClosingCharges { get; set; }
        public decimal ClosingTotal { get; set; }
    }
}
