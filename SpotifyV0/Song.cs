using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class Song
    {
        string _title;
        Artist _artist;
        Album _album;
        string _releaseDate;
        double _timeMillis;

        public string Title { get { return _title; } }
        public Artist Artist { get { return _artist; } }
        public Album Album { get { return _album; } }
        public string ReleaseDate { get { return _releaseDate; } }
        public double TimeMillis { get { return _timeMillis; } }
        public Song(string Title, Artist Artist, Album Album, double TimeMillis)
        {
            _title = Title;
            _artist = Artist;
            _album = Album;
            _timeMillis = TimeMillis;
        }
        public Song(string Title) { _title = Title; }
    }
}
