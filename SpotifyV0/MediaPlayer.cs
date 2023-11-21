using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class MediaPlayer
    {
        int _currentIndex;
        Song[] _songs;

        DateTime _timeNextSong;

        public int CurrentIndex { get { return _currentIndex;} }

        public Song Start(Song song)
        {
            DateTime now = DateTime.Now;
            _songs = _songs.Append(song).ToArray();
            _timeNextSong = now.AddMilliseconds(song.TimeMillis);
            return song;
        }
        public void Start(Playlist playlist) {
            _songs = playlist.Songs;
            _currentIndex = 0;
            Start(_songs[_currentIndex]);
        }
        public void PlayPause() { }
        public void Stop() { }
        public void Pause() { }
        public void Next() {
            if (_currentIndex < _songs.Length)
            {
                _currentIndex++;
                Start(_songs[_currentIndex]);
            }
        }
        public void Previous() {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                Start(_songs[_currentIndex]);
            }
        }
    }
}
