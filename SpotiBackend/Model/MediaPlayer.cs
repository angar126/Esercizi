using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class MediaPlayer
    {
        //UserListener User { get; set; };
        public int CurrentIndex { get; set; }
        public IPlayable[] Plays { get; set; }
    }
}
