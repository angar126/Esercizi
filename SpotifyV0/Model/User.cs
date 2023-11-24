using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0.Model
{
    abstract class User
    {
        int _id;
        string _name;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }

        public User(string Name)
        {
            _name = Name;
            //id sarà autogenerato
        }
    }
}
