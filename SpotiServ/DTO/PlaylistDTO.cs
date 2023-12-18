using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiData;

namespace SpotiServ
{
    public class PlaylistDTO: Music, ICountable
    {
        public string Name { get; set; }
        public int[] IdSongsDTO { get; set; }
        public int PlaylistIdDTO { get; set; }
        public void AddSong(int IdSong)
        {
            if (!IdSongsDTO.Contains(IdSong))
                IdSongsDTO = IdSongsDTO.Append(IdSong).ToArray();
        }
        public PlaylistDTO() { }
        public PlaylistDTO(Playlist playlist)
        {
            Id = playlist.Id;
            Rating = playlist.Rating;
            Name = playlist.Name;
            IdSongsDTO = playlist.IdSongs.Split('|').Select(s =>
            {
                int.TryParse(s, out int result);
                return result;
            }).ToArray();
            PlaylistIdDTO = playlist.PlaylistId;
        }
    }
}
