using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.SimpleHttp
{
    class Listener
    {
        private HttpListener httpListener;
        private HttpListenerContext context;

        public Listener()
        {
            this.httpListener = new HttpListener();
        }

        public async Task StartAsync(string port, RouteRepository routeRepository)
        {
            this.httpListener.Prefixes.Add(string.Format("http://localhost:{0}/", port));
            this.httpListener.Start();

            Console.WriteLine("Listening for requests on port {0}.", port);

            Request request = await GetNextRequestAsync();

            while (request != null)
            {
                Console.WriteLine("{0}: {1} {2}", DateTime.Now, request.Method, request.Endpoint);

                if (!TryRespond(request, routeRepository))
                    Console.WriteLine("HTTP 404 for {0}.", request.Endpoint);

                request = await GetNextRequestAsync();
            }
        }

        private bool TryRespond(Request request, RouteRepository routeRepository)
        {
            Dictionary<string, Action<Request, Response>> routes = routeRepository.GetRoutes(request.Method);

            if (routes == null || !routes.ContainsKey(request.Endpoint))
                return false;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
                {
                    routes[request.Endpoint](request, new Response(context.Response));
                };

            try
            {
                worker.RunWorkerAsync();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private async Task<Request> GetNextRequestAsync()
        {
            try
            {
                this.context = await this.httpListener.GetContextAsync();
                HttpListenerRequest httpRequest = this.context.Request;
                return new Request(httpRequest);
            }
            catch (Exception)
            {
                //TODO: output/log exception
                return null;
            }
        }
    }
}
