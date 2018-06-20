using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFChatService)))
            {
                host.Open();
                Console.WriteLine("Server Open!");
                Console.ReadKey();
            }
        }
    }
}
