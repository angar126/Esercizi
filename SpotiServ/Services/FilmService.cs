using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpotiData;

namespace SpotiServ.Services
{
    public class FilmService : IService<Film, FilmDTO>
    {

        readonly FilmRepository<Film, FilmDTO, FilmDTO> _FilmRepository;

        static FilmService instance;
        FilmService()
        {
            _FilmRepository = new FilmRepository<Film, FilmDTO, FilmDTO>(@"D:\logs\");
        }
        public static FilmService GetInstance()
        {
            if (instance is null)
            {
                instance = new FilmService();
            }
            return instance;
        }
        public List<FilmDTO> GetAll()
        {

            return _FilmRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public FilmDTO Get(int Id)
        {
            List<FilmDTO> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public FilmDTO Update() { return null; }
        public FilmDTO Delete(int Id) { return null; }
    }
}

