using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiControl.DTO
{
    public class FilmDTO : IPlayable
    {
        //public int Id { get; set; }
        public double TimeMillis { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public DirectorDTO Director { get; set; }
        public FilmDTO(string title, DirectorDTO director)
        {
            Title = title;
            Director = director;
            Rating = 0;
        }
    }
}
