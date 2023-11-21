using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    abstract class User
    {
        int _id;
        string _name;
        Playlist[] _playlists;
        public int Id { get { return _id; } }
        public string Name { get { return _name;} }
        public Playlist[] Playlist { get {  return _playlists; } }
        public User(string Name) {
         _name = Name;
        //id sarà autogenerato
        }
    }
}
