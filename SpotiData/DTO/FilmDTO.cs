using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class FilmDTO : IPlayable
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public DirectorDTO DirectorDTO { get; set; }
       
    }
}
