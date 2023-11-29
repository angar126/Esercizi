using System;
using Proxy;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxySingleton instance = ProxySingleton.GetInstance();

            Console.WriteLine(instance.Ip1);
            Console.WriteLine(instance.Ip2);

            ProxySingleton instance2 = ProxySingleton.GetInstance();

            Console.WriteLine(instance2.Ip1);
            Console.WriteLine(instance2.Ip2);

            ProxySingleton instance3 = ProxySingleton.GetInstance();

            Console.WriteLine(instance3.Ip1);
            Console.WriteLine(instance3.Ip2);

            ProxySingleton instance4 = ProxySingleton.GetInstance();

            Console.WriteLine(instance4.Ip1);
            Console.WriteLine(instance4.Ip2);
        }
    }
}
