
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    internal class GenericDbContext<T, Rs> : DbContext where T : class, new()
    {
        //private readonly IMapper _mapper;
        public List<Rs> Data; // ServiceDTo
        public GenericDbContext(string path) : base(path)
        {

            var dataFromDb = ReadFromCsv<T>(path + typeof(T).Name.ToString() + ".csv");

            // Assuming Res has a constructor that accepts a T instance
            Data = dataFromDb.Select(item => Activator.CreateInstance(typeof(Rs), item)).Cast<Rs>().ToList();
        }

    }
}
