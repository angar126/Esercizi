using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SpotiData;
using Newtonsoft.Json;

namespace SpotiServ.Services
{
    public class AlbumService : IService<Album, AlbumDTO>
    {
        private readonly string spotiApiBaseUrl = "http://172.18.0.3:8000"; // Sostituisci con l'indirizzo effettivo del tuo servizio SpotiAPI
        private readonly HttpClient httpClient;

        static AlbumService instance;
        AlbumService()
        {
            httpClient = new HttpClient();
        }

        public static AlbumService GetInstance()
        {
            if (instance is null)
            {
                instance = new AlbumService();
            }
            return instance;
        }

        public async Task<List<AlbumDTO>> GetAllApi()
        {
            var response = await httpClient.GetStringAsync($"{spotiApiBaseUrl}/api/Album");
            return JsonConvert.DeserializeObject<List<AlbumDTO>>(response);
        }

        public async Task<AlbumDTO> GetApi(int Id)
        {
            var response = await httpClient.GetStringAsync($"{spotiApiBaseUrl}/api/Album/{Id}");
            return JsonConvert.DeserializeObject<AlbumDTO>(response);
        }
        public void Dispose()
        {
            httpClient.Dispose();
        }
        //li rimando sincroni per prova
        public AlbumDTO Get(int Id)
        {
            return GetApi(Id).Result;
        }
        public List<AlbumDTO> GetAll()
        {
            return GetAllApi().Result;
        }
        public AlbumDTO Update() { return null; }
        public AlbumDTO Update(AlbumDTO album) { return null; }
        public AlbumDTO Delete(int Id) { return null; }
    }
}
    //public class AlbumService : IService<Album, AlbumDTO>
    //{

//readonly MusicRepository<Album, AlbumDTO, AlbumDTO> _MusicRepository;

//static AlbumService instance;
//AlbumService()
//{
//    _MusicRepository = new MusicRepository<Album, AlbumDTO, AlbumDTO>(@"C:\Users\user\Desktop\csv");
//}
//public static AlbumService GetInstance()
//{
//    if (instance is null)
//    {
//        instance = new AlbumService();
//    }
//    return instance;
//}
//public List<AlbumDTO> GetAll()
//{

//    return _MusicRepository.GetAll().ToList();

//}
//public AlbumDTO Get(int Id)
//{
//    List<AlbumDTO> items = GetAll();
//    return items.FirstOrDefault(s => s.Id == Id);
//}
//public AlbumDTO Update() { return null; }
//public AlbumDTO Update(AlbumDTO album) { return null; }
//public AlbumDTO Delete(int Id) { return null; }
//}
