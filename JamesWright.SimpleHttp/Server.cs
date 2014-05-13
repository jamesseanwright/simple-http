using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesWright.SimpleHttp
{
    public class Server
    {
        private Listener listener;

        public Dictionary<string, Action<Request, Response>> Routes { get; private set; }

        public Server()
        {
            this.listener = new Listener();
            Routes = new Dictionary<string, Action<Request, Response>>();
        }

        public void Start(string[] args = null)
        {
            Console.Write("SimpleHttp server 0.1\n\n");
            string port = "8005";

            if (args != null && args.Length > 0)
                port = args[0];

            Console.WriteLine("Initialising server on port {0}...", port);
            this.listener.Start(port, Routes);
        }
    }
}
