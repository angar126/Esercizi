﻿using System;
using System.Collections.Generic;
using System.Linq;
using SpotiUtil;


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
            Songs = new List<Song>();
            Artists = new List<Artist>();
            Albums = new List<Album>();
            Playlists = new List<Playlist>();
            musicDtos = ReadFromCsv<MusicDto>(path);// + typeof(Song).Name.ToString() + ".csv");
            MergerData();
        }
        public void MergerData()
        {
            
            List<Song> songs = new List<Song>();

            foreach (var musicDto in musicDtos)
            {
                bool pass = true;
                if (pass && musicDto.Artist != null && musicDto.Title != null && musicDto.Album != null)
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
                    if (album == null)
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

                        Songs.Add(song);
                    }
                    else
                    {//todo
                    }
                    if (musicDto.Playlist != null)
                    {
                        Playlist playlist = Playlists.FirstOrDefault(a => a.PlaylistId == musicDto.PlaylistId);
                        if (playlist == null)
                        {
                            playlist = new Playlist(musicDto.Playlist);
                            playlist.PlaylistId = musicDto.PlaylistId;
                            Playlists.Add(playlist);
                            playlist.Rating = 1;

                        }
                        else
                        {
                            playlist.Rating++;
                        }
                        playlist.AddSong(song);
                    }
                }
                else Logger.LogInfo($"Error data null, ID SONG in CSV: {musicDto.Id}");
                pass = true;
            }

        }

    }
}
