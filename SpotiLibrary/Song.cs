using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiModel
{
    public class Song : IPlayable
    {
        int _id;
        string _title;
        Artist _artist;
        Album _album;
        string _releaseDate;
        double _timeMillis;
        string _genre;
        int _count;
        
        public string Title { get { return _title; } set { _title = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public Artist Artist { get { return _artist; } }
        public Album Album { get { return _album; } }
        public string ReleaseDate { get { return _releaseDate; } }
        public int Count { get { return _count; } set { _count = value; } }
        public double TimeMillis { get { return _timeMillis; } }
        public Song(string Title, Artist Artist, Album Album, double TimeMillis)
        {
            _title = Title;
            _artist = Artist;
            _album = Album;
            _timeMillis = TimeMillis;
        }
        public Song(string Title, Artist Artist, Album Album, double TimeMillis, int Count)
        {
            _title = Title;
            _artist = Artist;
            _album = Album;
            _timeMillis = TimeMillis;
            _count = Count;
        }
        public Song(string Title) { _title = Title; }
        public Song() { }
    }
}
