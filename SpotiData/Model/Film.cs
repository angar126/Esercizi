﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class Film 
    {
        public int Id { get; set; }
        public double TimeMillis { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public Director Director { get; set; }
       
    }
}
