﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SpotiData;

namespace SpotiServ
{
    public class DirectorDTO:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

    }
}
