
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    internal class GenericDbContext<T, Rs> : DbContext where T : class, new()
    {
        //private readonly IMapper _mapper;
        public List<Rs> Data; // ServiceDTo
        public GenericDbContext(IConfiguration configuration, ILogger<DbContext> logger) : base(configuration, logger)
        {

            var dataFromDb = ReadFromCsv<T>(configuration.GetConnectionString("DefaultConnection") + typeof(T).Name.ToString() + ".csv");

            // Assuming Res has a constructor that accepts a T instance
            Data = dataFromDb.Select(item => Activator.CreateInstance(typeof(Rs), item)).Cast<Rs>().ToList();
        }

    }
}
