using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class FilmRepository<T, Rq, Rs> where T : class, new() where Rs : class, new() where Rq : class, new()
    {
        private readonly GenericDbContext<T, Rs> Db;

        public FilmRepository(string path)
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
}
