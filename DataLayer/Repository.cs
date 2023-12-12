using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Repository<T, Rq, Rs> : IRepository<T, Rq, Rs> where T : class, new() where Rs : class, new() where Rq : class, new()
    {
        private readonly GenericDbContext<T, Rs> Db;

        public Repository(string path)
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

    internal interface IRepository<T, Rq, Rs> where Rq : class, new() where Rs : class, new()
    {
        void Update(List<Rq> items);
        List<Rs> GetAll();
    }
}