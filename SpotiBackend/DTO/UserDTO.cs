using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiBackend
{
    public abstract class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
