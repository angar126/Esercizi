using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

        public Repository(IConfiguration prov, ILogger<DbContext> logger)
        {
            Db = new GenericDbContext<T, Rs>(prov, logger);
        }

        public List<Rs> GetAll()
        {
            return Db.Data;
        }

        public void Update(List<Rq> items)
        {
            // toDO
        }
        public void Update(Rq items)
        {
            
        }

    }

    public interface IRepository<T, Rq, Rs> where Rq : class, new() where Rs : class, new()
    {
        void Update(List<Rq> items);
        List<Rs> GetAll();
        public void Update(Rq items);
    }
}