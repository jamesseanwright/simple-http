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

                if (!await TryRespondAsync(request, routeRepository))
                    Console.WriteLine("HTTP 404 for {0}.", request.Endpoint);

                request = await GetNextRequestAsync();
            }
        }

        private async Task<bool> TryRespondAsync(Request request, RouteRepository routeRepository)
        {
            Dictionary<string, Action<Request, Response>> routes = routeRepository.GetRoutes(request.Method);

            if (routes == null || !routes.ContainsKey(request.Endpoint))
                return false;

            // TODO: Thread pooling!
            await Task.Run(() =>
                {
                    routes[request.Endpoint](request, new Response(context.Response));
                });

            return true;
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
