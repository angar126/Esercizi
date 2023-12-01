using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
