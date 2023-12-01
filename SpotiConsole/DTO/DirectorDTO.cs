using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiControl.DTO
{
    public class DirectorDTO:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public DirectorDTO(string name)
        {
            Name = name;
            Rating = 0;
        }
    }
}
