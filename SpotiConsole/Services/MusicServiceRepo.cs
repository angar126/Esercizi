using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SpotiBackend;

namespace SpotiControl
{
    public class MusicServiceRepo : IService<Song, SongDTO>
    {

        readonly MusicRepository<Song, SongDTO, SongDTO> _MusicRepository;

        static MusicServiceRepo instance;
        MusicServiceRepo()
        {
            _MusicRepository = new MusicRepository<Song, SongDTO, SongDTO>(@"D:\logs\");
        }
        public static MusicServiceRepo GetInstance()
        {
            if (instance is null)
            {
                instance = new MusicServiceRepo();
            }
            return instance;
        }
        public List<SongDTO> GetAll()
        {

            return _MusicRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public SongDTO Get(int Id) { return null; }
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

