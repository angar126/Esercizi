using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ProxySingleton
    {
        private static ProxySingleton _instance;
        string _ip2;
        string _ip1;
        public string Ip1 { get { return _ip1; } }
        public string Ip2 { get { return _ip2; } }
        ProxySingleton() {
            Random rnd = new Random();
            _ip1 = $"{rnd.Next(0, 256)}.{rnd.Next(0, 256)}.{rnd.Next(0, 256)}.{rnd.Next(0, 256)}";
            _ip2 = $"{rnd.Next(0, 256)}.{rnd.Next(0, 256)}.{rnd.Next(0, 256)}.{rnd.Next(0, 256)}"; 
        }
        public static ProxySingleton GetInstance() {
            if (_instance == null) {
                _instance = new ProxySingleton();
                    }
            return _instance; 
        }

    }
}
