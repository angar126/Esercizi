﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class RadioDTO: Music, ICountable
    {
        
        public string Name { get; set; }
        public PlaylistDTO OnAirPlaylistDTO { get; set; }
        
    }
}
