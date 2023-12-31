﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiData;

namespace SpotiServ.Services
{
    public class AlbumService : IService<Album, AlbumDTO>
    {

        readonly MusicRepository<Album, AlbumDTO, AlbumDTO> _MusicRepository;

        static AlbumService instance;
        AlbumService()
        {
            _MusicRepository = new MusicRepository<Album, AlbumDTO, AlbumDTO>(@"C:\Users\user\Desktop\csv");
        }
        public static AlbumService GetInstance()
        {
            if (instance is null)
            {
                instance = new AlbumService();
            }
            return instance;
        }
        public List<AlbumDTO> GetAll()
        {

            return _MusicRepository.GetAll().ToList();

        }
        public AlbumDTO Get(int Id)
        {
            List<AlbumDTO> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public AlbumDTO Update() { return null; }
        public AlbumDTO Update(AlbumDTO album) { return null; }
        public AlbumDTO Delete(int Id) { return null; }
    }

}
