using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class Music
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public void Play()
        {
            Rating++;
        }
    }
}
