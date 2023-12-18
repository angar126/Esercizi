using System;

namespace SpotiData
{
    public class MusicDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Playlist { get; set; }
        public int PlaylistId { get; set; }
    }

}
