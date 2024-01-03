using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotiData;

namespace SpotiServ.Services
{
    public class ArtistService : IService<Artist, ArtistDTO>
    {
        private readonly string spotiApiBaseUrl = "http://172.18.0.3:8000"; // Sostituisci con l'indirizzo effettivo del tuo servizio SpotiAPI
        private readonly HttpClient httpClient;

        static ArtistService instance;
        ArtistService()
        {
            httpClient = new HttpClient();
        }

        public static ArtistService GetInstance()
        {
            if (instance is null)
            {
                instance = new ArtistService();
            }
            return instance;
        }

        public async Task<List<ArtistDTO>> GetAllApi()
        {
            var response = await httpClient.GetStringAsync($"{spotiApiBaseUrl}/api/Artist");
            return JsonConvert.DeserializeObject<List<ArtistDTO>>(response);
        }

        public async Task<ArtistDTO> GetApi(int Id)
        {
            var response = await httpClient.GetStringAsync($"{spotiApiBaseUrl}/api/Artist/{Id}");
            return JsonConvert.DeserializeObject<ArtistDTO>(response);
        }
        public void Dispose()
        {
            httpClient.Dispose();
        }
        //li rimando sincroni per prova
        public ArtistDTO Get(int Id)
        {
            return GetApi(Id).Result;
        }
        public List<ArtistDTO> GetAll()
        {
            return GetAllApi().Result;
        }
        public ArtistDTO Update() { return null; }
        public ArtistDTO Update(ArtistDTO artist) { return null; }
        public ArtistDTO Delete(int Id) { return null; }
    }
    //readonly MusicRepository<Artist, ArtistDTO, ArtistDTO> _MusicRepository;

    //static ArtistService instance;
    //ArtistService()
    //{
    //    _MusicRepository = new MusicRepository<Artist, ArtistDTO, ArtistDTO>(@"C:\Users\user\Desktop\csv");
    //}
    //public static ArtistService GetInstance()
    //{
    //    if (instance is null)
    //    {
    //        instance = new ArtistService();
    //    }
    //    return instance;
    //}
    //public List<ArtistDTO> GetAll()
    //{

    //    return _MusicRepository.GetAll().ToList();//_MusicRepository.GetAll().Select(i => new SongDTO(i)).ToList();

    //}
    //public ArtistDTO Get(int Id)
    //{
    //    List<ArtistDTO> items = GetAll();
    //    return items.FirstOrDefault(s => s.Id == Id);
    //}
    //public ArtistDTO Update() { return null; }
    //public ArtistDTO Update(ArtistDTO artist) { return null; }
    //public ArtistDTO Delete(int Id) { return null; }
}
