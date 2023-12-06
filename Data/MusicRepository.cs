using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MusicRepository<T, Rq, Rs> : IRepository<T, Rq, Rs> where T : class, new() where Rs : Music, new() where Rq : Music, new()
    {
        private readonly GenericDbContext<T, Rs> Db;

        public MusicRepository(string path)
        {
            Db = new GenericDbContext<T, Rs>(path);
        }

        public List<Rs> GetAll()
        {
            return Db.Data;
        }

        public void Update(List<Rq> items)
        {
            // toDO
        }
    }

    internal interface IRepository<T, Rq, Rs>
    {
        void Update(List<Rq> items);
        List<Rs> GetAll();
    }
}