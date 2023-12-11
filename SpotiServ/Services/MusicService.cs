using SpotiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServ.Services
{
    class MusicService: IService<MusicDto,SongDTO>
    {
        readonly MusicRepository<MusicDto, SongDTO, SongDTO> _MusicRepository;

        static MusicService instance;
        MusicService()
        {
            _MusicRepository = new MusicRepository<MusicDto, SongDTO, SongDTO>(@"D:\logs\");
        }
        public static MusicService GetInstance()
        {
            if (instance is null)
            {
                instance = new MusicService();
            }
            return instance;
        }
        public List<SongDTO> GetAll()
        {
            return _MusicRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public SongDTO Get(int Id)
        {
            List<SongDTO> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public SongDTO Update() { return null; }
        public SongDTO Delete(int Id) { return null; }
        //public List<Artist> GetAllArtist()
        //{
        //    return GetAll().Select()
        //               .Distinct()
        //               .ToArray();
        //}
    }
}
