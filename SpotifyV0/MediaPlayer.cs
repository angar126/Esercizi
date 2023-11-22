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
        public MediaPlayer() { }
        public MediaPlayer(Song[] Songs) {
            _songs = Songs;
            _currentIndex = 0; }
        public int CurrentIndex { get { return _currentIndex;} }

        public Song Start(Song song)
        {
            DateTime now = DateTime.Now;
            _songs = _songs.Append(song).ToArray();
            _timeNextSong = now.AddMilliseconds(song.TimeMillis);
            return song;
        }
        public Song Start(IPlaylist playlist) {
            _songs = playlist.Songs;
            return Start(_songs[_currentIndex]);
        }
        public void PlayPause() { }
        public void Stop() { }
        public void Pause() { }
        public Song Next() {
            if (_currentIndex < _songs.Length)
            {
                _currentIndex++;
                return Start(_songs[_currentIndex]);
            }
            _currentIndex = 0;
            return Start(_songs[_currentIndex]);
        }
        public Song Previous() {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                return Start(_songs[_currentIndex]);
            }
            _currentIndex = 0;
            return Start(_songs[_currentIndex]);
        }
    }
}
