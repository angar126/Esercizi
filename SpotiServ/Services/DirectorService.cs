using SpotiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServ.Services
{
    public class DirectorService : IService<Director, DirectorDTO>
    {

        readonly FilmRepository<Director, DirectorDTO, DirectorDTO> _FilmRepository;

        static DirectorService instance;
        DirectorService()
        {
            _FilmRepository = new FilmRepository<Director, DirectorDTO, DirectorDTO>(@"D:\logs\");
        }
        public static DirectorService GetInstance()
        {
            if (instance is null)
            {
                instance = new DirectorService();
            }
            return instance;
        }
        public List<DirectorDTO> GetAll()
        {

            return _FilmRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public DirectorDTO Get(int Id)
        {
            List<DirectorDTO> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public DirectorDTO Update() { return null; }
        public DirectorDTO Delete(int Id) { return null; }
    }
}