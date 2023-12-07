using SpotiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServ
{
    public class PlaylistService : IService<Playlist, PlaylistDTO>
    {
        readonly MusicRepository<Playlist, PlaylistDTO, PlaylistDTO> _PlaylistRepository;

        static PlaylistService instance;
        PlaylistService()
        {
            _PlaylistRepository = new MusicRepository<Playlist, PlaylistDTO, PlaylistDTO>(@"D:\logs\");
        }

        public static PlaylistService GetInstance()
        {
            if (instance is null)
            {
                instance = new PlaylistService();
            }
            return instance;
        }

        public List<PlaylistDTO> GetAll()
        {
            return _PlaylistRepository.GetAll().ToList();
        }

        public PlaylistDTO Get(int Id)
        {
            List<PlaylistDTO> playlists = GetAll();
            return playlists.FirstOrDefault(p => p.PlaylistIdDTO == Id);
        }

        public PlaylistDTO Update(PlaylistDTO pDTO)
        {
            // Implementa la logica di aggiornamento per le playlist
            return null;
        }

        public PlaylistDTO Delete(int Id)
        {
            // Implementa la logica di cancellazione per le playlist
            return null;
        }
    }

}
