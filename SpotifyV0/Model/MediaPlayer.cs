using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyV0.Interfaces;

namespace SpotifyV0.Model
{
    class MediaPlayer
    {
        int _currentIndex;
        Song[] _songs;

        DateTime _timeNextSong;
        public MediaPlayer() { }
        public MediaPlayer(Song[] Songs)
        {
            _songs = Songs;
            _currentIndex = 0;
        }
        public MediaPlayer(Song Song)
        {
            _songs = new Song[] { Song };
            _currentIndex = 0;
        }
        public int CurrentIndex { get { return _currentIndex; } }
        public Song[] Songs { get { return _songs; } set { _songs = value; } }
        public Song Start(Song song)
        {
            DateTime now = DateTime.Now;
            //_songs = _songs.Append(song).ToArray();
            song.Count++;
            song.Artist.Count++;
            song.Album.Count++;
            _timeNextSong = now.AddMilliseconds(song.TimeMillis);
            return song;
        }
        public Song Start(IPlaylist playlist)
        {
            _songs = playlist.Songs;
            playlist.Count++;
            return Start(_songs[_currentIndex]);
        }
        public Song PlayPause()
        {
            return _songs[_currentIndex];
        }
        public void Stop() { }
        public void Pause() { }
        public Song Next()
        {
            if (_currentIndex < _songs.Length - 1)
            {
                _currentIndex++;
            }
            return Start(_songs[_currentIndex]);
        }
        public Song Previous()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
            }
            return Start(_songs[_currentIndex]);
        }
    }
}
