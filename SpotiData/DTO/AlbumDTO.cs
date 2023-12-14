using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class AlbumDTO: Music, ICountable
    {
        public string Name { get; set; }
        
        public int[] IdSongs { get; set; }
        public int IdArtist { get; set; }

        public AlbumDTO(Album album)
        {
            Id= album.Id;
            Rating = album.Rating;
            Name = album.Name;
            IdSongs = album.IdSongs.Split('|').Select(s =>
            {
                int.TryParse(s, out int result);
                return result;
            }).ToArray();
            IdArtist = album.IdArtist;
        }
        public AlbumDTO() { }
    }
}
