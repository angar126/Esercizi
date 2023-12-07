using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiData;

namespace SpotiServ.Services
{
    class ArtistService : IService<Artist, ArtistDTO>
    {

        readonly MusicRepository<Artist, ArtistDTO, ArtistDTO> _MusicRepository;

        static ArtistService instance;
        ArtistService()
        {
            _MusicRepository = new MusicRepository<Artist, ArtistDTO, ArtistDTO>(@"D:\logs\");
        }
        public static ArtistService GetInstance()
        {
            if (instance is null)
            {
                instance = new ArtistService();
            }
            return instance;
        }
        public List<ArtistDTO> GetAll()
        {

            return _MusicRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public ArtistDTO Get(int Id)
        {
            List<ArtistDTO> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public ArtistDTO Update() { return null; }
        public ArtistDTO Delete(int Id) { return null; }
    }
}
