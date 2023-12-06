using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class MediaPlayer
    {
        //UserListener user;
        int _currentIndex;
        IPlayable[] _plays;

        //DateTime _timeSong;
        public MediaPlayer() { }
        public MediaPlayer(SongDTO[] Songs)
        {
            _plays = Songs;
            _currentIndex = 0;
        }
        public MediaPlayer(SongDTO Song)
        {
            _plays = new SongDTO[] { Song };
            _currentIndex = 0;
        }
        public MediaPlayer(Film Film)
        {
            _plays = new Film[] { Film };
            _currentIndex = 0;
        }
        public MediaPlayer(Film[] Films)
        {
            _plays = Films;
            _currentIndex = 0;
        }
        public int CurrentIndex { get { return _currentIndex; } }
        public IPlayable[] Plays { get { return _plays; } set { _plays = value; } }
        public IPlayable Start(IPlayable play)
        {
            // DateTime now = DateTime.Now;
            //_songs = _songs.Append(song).ToArray();
            play.Rating++;
            if (play is SongDTO)
            {
                SongDTO song = (SongDTO)play;
                song.ArtistDTO.Rating++;
                song.AlbumDTO.Rating++;
            }
            if (play is Film)
            {
                Film film = (Film)play;
                film.Director.Rating++;

            }
            //_timeSong = now.AddMilliseconds(song.TimeMillis);
            //user.TimeSpan = TimeSpan.FromMilliseconds((double)song.TimeMillis);
            return play;
        }
        public SongDTO Start(IPlaylist playlist)
        {
            _plays = playlist.Songs;
            playlist.Rating++;
            return (SongDTO)Start(_plays[_currentIndex]);
        }
        public Film Start(Film[] playlist)
        {
            _plays = playlist;
            //playlist.Count++;
            return (Film)Start(_plays[_currentIndex]);
        }
        public IPlayable PlayPause()
        {
            return _plays[_currentIndex];
        }
        public void Stop() { }
        public void Pause() { }
        public IPlayable Next()
        {
            if (_currentIndex < _plays.Length - 1)
            {
                _currentIndex++;
            }
            return Start(_plays[_currentIndex]);
        }
        public IPlayable Previous()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
            }
            return Start(_plays[_currentIndex]);
        }
    }
}
