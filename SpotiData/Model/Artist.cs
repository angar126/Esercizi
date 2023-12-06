﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class Artist:ICountable
    {
        public string Name { get; set; }
        public Album[] Albums { get; set; } = Array.Empty<Album>();
        public string Genre { get; set; }
        public int Rating { get; set; }
        
    }
}
