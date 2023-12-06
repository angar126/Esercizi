using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServ
{
    internal interface IService<T,DtoRes>
    {
        public DtoRes Get(int Id);
        public DtoRes Update();
        public List<DtoRes> GetAll();
        public DtoRes Delete(int Id);
    }
}
