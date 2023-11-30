using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    public class Film:IPlayable
    {
        int _id;
        string _title;
        Director _director;
        double _timeMillis;
        string _genre;
        int _count;
        public int Count { get { return _count; } set { _count = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public Director Director { get { return _director; } set { _director = value; } }

        public Film (string title, Director director)
        {         
            Title = title;
            Director = director;
            Count = 0;
        }
    }
}
