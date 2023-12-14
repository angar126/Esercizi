using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiData;
using SpotiServ.Services;

namespace SpotiServ
{    public class MediaPlayer
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
        public MediaPlayer(FilmDTO Film)
        {
            _plays = new FilmDTO[] { Film };
            _currentIndex = 0;
        }
        public MediaPlayer(FilmDTO[] Films)
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
                AlbumService albumService = AlbumService.GetInstance();
                ArtistService artistService = ArtistService.GetInstance();

                ArtistDTO a = artistService.Get(song.IdArtistDTO);
                a.Rating++;
                artistService.Update(a);

                AlbumDTO al = albumService.Get(song.IdAlbumDTO);
                al.Rating++;
                albumService.Update(al);
            }
            if (play is FilmDTO)
            {
                FilmDTO film = (FilmDTO)play;
                film.DirectorDTO.Rating++;

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
        public FilmDTO Start(FilmDTO[] playlist)
        {
            _plays = playlist;
            //playlist.Count++;
            return (FilmDTO)Start(_plays[_currentIndex]);
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
