using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Summary
    {
        public Guid Id { get; set; }

        public DateOnly ExDate { get; set; }
        public DateOnly DividendDate { get; set; }
        public decimal Dividend { get; set; }
        public decimal DividendCharges { get; set; }
        public decimal DividendTotal { get; set; }

        public decimal TotalCharges { get; set; }
        public decimal Gross { get; set; }
        public decimal Net { get; set; }
        public decimal Profit { get; set; }
    }
}
