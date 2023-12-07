using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiData;

namespace SpotiServ.Services
{
     class RadioService : IService<Radio, RadioDTO>
    {

        readonly MusicRepository<Radio, RadioDTO, RadioDTO> _MusicRepository;

        static RadioService instance;
        RadioService()
        {
            _MusicRepository = new MusicRepository<Radio, RadioDTO, RadioDTO>(@"D:\logs\");
        }
        public static RadioService GetInstance()
        {
            if (instance is null)
            {
                instance = new RadioService();
            }
            return instance;
        }
        public List<RadioDTO> GetAll()
        {

            return _MusicRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public RadioDTO Get(int Id)
        {
            List<RadioDTO> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public RadioDTO Update() { return null; }
        public RadioDTO Delete(int Id) { return null; }
    }
}
