using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public interface IPlayable:ICountable
    {
        public string Title { get; set; }
    }
}
