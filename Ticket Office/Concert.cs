﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
    public class Concert
    {
        public int Id { get; set; }
        public bool ReducedVenue { get; set; }
        public DateTime Date { get; set; }
        public string Performer { get; set; }
        public int BeginsAt {  get; set; }
        public int FullCapacitySales { get; set; }

    }
}
