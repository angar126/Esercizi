using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiData;

namespace SpotiServ.Services
{
    public class UserListenerService : IService<UserListener, UserListenerDTO>
    {

        readonly MusicRepository<UserListener, UserListenerDTO, UserListenerDTO> _MusicRepository;

        static UserListenerService instance;
        UserListenerService()
        {
            _MusicRepository = new MusicRepository<UserListener, UserListenerDTO, UserListenerDTO>(@"D:\logs\");
        }
        public static UserListenerService GetInstance()
        {
            if (instance is null)
            {
                instance = new UserListenerService();
            }
            return instance;
        }
        public List<UserListenerDTO> GetAll()
        {

            return _MusicRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

        }
        public UserListenerDTO Get(int Id)
        {
            List<UserListenerDTO> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public UserListenerDTO Update() { return null; }
        public UserListenerDTO Delete(int Id) { return null; }
    }
}
