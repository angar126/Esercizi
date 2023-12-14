using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SpotiData;

namespace SpotiServ
{
    public class SongService : IService<Song, SongDTO>
    {

        readonly MusicRepository<Song, SongDTO, SongDTO> _MusicRepository;

        static SongService instance;
        SongService()
        {
            _MusicRepository = new MusicRepository<Song, SongDTO, SongDTO>(@"C:\Users\user\Desktop\csv");
        }
        public static SongService GetInstance()
        {
            if (instance is null)
            {
                instance = new SongService();
            }
            return instance;
        }
        public List<SongDTO> GetAll()
        {

            return _MusicRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public SongDTO Get(int Id) {
            List<SongDTO> songs = GetAll();
            return songs.FirstOrDefault(s => s.Id == Id); 
        }
        public List<SongDTO> GetAllByArtist(int IdArtist)
        {
            return GetAll().Where(s=>s.IdArtistDTO == IdArtist).ToList();
        }
        public List<SongDTO> GetAllByAlbum(int IdAlbum)
        {
            return GetAll().Where(s => s.IdAlbumDTO == IdAlbum).ToList();
        }
        public List<SongDTO> GetAllByPlaylist(int IdPlaylist)
        {
            return GetAll().Where(s => s.PlaylistId == IdPlaylist).ToList();
        }
        public SongDTO Update() { return null; }
        public SongDTO Delete(int Id) { return null; }
    }

}
public class HRCustomException : Exception
{
    public HRCustomException(string msg) : base(msg)
    {

    }
}

