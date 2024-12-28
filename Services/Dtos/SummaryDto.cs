using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class SummaryDto
    {
        public Guid Id { get; set; }
        [Required]
        public DateOnly ExDate { get; set; }
        [Required]
        public DateOnly DividendDate { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The Dividend value must be 0 or greater.")]
        public decimal Dividend { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The Dividend Commission value must be 0 or greater.")]
        public decimal DividendCharges { get; set; }
        public decimal DividendTotal { get; set; }

        public decimal TotalCharges { get; set; }
        public decimal Gross { get; set; }
        public decimal Net { get; set; }
        public decimal Profit { get; set; }
    }
}
