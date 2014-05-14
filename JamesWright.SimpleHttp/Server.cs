using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Start(string port)
        {
            Console.Write("SimpleHttp server 0.1\n\n");
            Console.WriteLine("Initialising server on port {0}...", port);
            this.listener.Start(port, RouteRepository);
        }
    }
}
