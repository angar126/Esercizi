using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpotiBackend
{
    public class MusicDbContext: DbContext
    {
        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Playlist> Playlists { get; set; }

        List<MusicDto> musicDtos;
        public MusicDbContext(string path) : base(path) {

            musicDtos = ReadFromCsv<MusicDto>(path);// + typeof(Song).Name.ToString() + ".csv");
            MergerData();
        }

        public void MergerData()
        {
            
            List<Song> songs = new List<Song>();

            foreach (var musicDto in musicDtos)
            {
                Artist? artist = Artists.FirstOrDefault(a => a.Name == musicDto.Artist);

                if (artist == null)
                {
                    artist = new Artist(musicDto.Artist);
                    artist.Genre = musicDto.Genre;
                    Artists.Add(artist);
                    artist.Rating = 1;
                }
                else
                {
                    artist.Rating++;
                }  

                Album? album = Albums.FirstOrDefault(a => a.Name == musicDto.Album);
                if(album == null)
                {
                    album = new Album(musicDto.Album, artist);
                    album.Genre = musicDto.Genre;
                    artist.AddAlbum(album);
                    Albums.Add(album);
                    album.Rating = 1;
                }
                else
                {
                    album.Rating++;
                }
                bool Plbool = musicDto.PlaylistId != null;
                
                Song? song = Songs.FirstOrDefault(a => a.Id == musicDto.Id);
                if (song == null)
                {
                    song = new Song
                    {
                        Id = musicDto.Id,
                        Rating = musicDto.Rating,
                        Title = musicDto.Title,
                        Artist = artist,
                        Album = album,
                        Genre = musicDto.Genre,
                    };
                    album.AddSong(song);
                    

                }
                else
                {//todo
                }
                if (Plbool)
                {
                    Playlist? playlist = Playlists.FirstOrDefault(a => a.PlaylistId == musicDto.PlaylistId);
                    if (playlist == null)
                    {
                        playlist = new Playlist(musicDto.Playlist);
                        playlist.PlaylistId = musicDto.PlaylistId;
                        Albums.Add(album);
                        playlist.Rating = 1;
                        
                    }
                    else
                    {
                        playlist.Rating++;
                    }
                    playlist.AddSong(song);
                }
            }

        }

    }
}
