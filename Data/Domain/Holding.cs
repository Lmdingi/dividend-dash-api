﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Holding
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Transaction? Transaction { get; set; }
        public Summary? Summary { get; set; }
    }
}
