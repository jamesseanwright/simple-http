using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.SimpleHttp
{
    class Server
    {
        private Listener listener;
        public RouteRepository RouteRepository { get; private set; }

        public Server(Listener listener, RouteRepository routeRepository)
        {
            this.listener = listener;
            RouteRepository = routeRepository;
        }

        public async Task StartAsync(string port)
        {
            Console.Write("SimpleHttp server 0.2\n\n");
            Console.WriteLine("Initialising server on port {0}...", port);
            await this.listener.StartAsync(port, RouteRepository);
        }
    }
}
