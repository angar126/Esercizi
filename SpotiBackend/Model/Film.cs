using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Film:IPlayable
    {
        public int Id { get; set; }
        public double TimeMillis { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public Director Director { get; set; }
    }
}
