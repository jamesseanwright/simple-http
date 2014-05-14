using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

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

        public void Start(string port, RouteRepository routeRepository)
        {
            this.httpListener.Prefixes.Add(string.Format("http://localhost:{0}/", port));
            this.httpListener.Start();

            Console.WriteLine("Listening for requests on port {0}.", port);

            Request request;

            while (TryGetNextRequest(out request))
            {
                Console.WriteLine("{0}: {1}", DateTime.Now, request.Endpoint);

                if (!TryRespond(request, routeRepository))
                    Console.WriteLine("No handler specified for endpoint {0}.", request.Endpoint);
            }
        }

        private bool TryRespond(Request request, RouteRepository routeRepository)
        {
            if (!routeRepository.Get.ContainsKey(request.Endpoint))
                return false;

            routeRepository.Get[request.Endpoint](request, new Response(context.Response));
            return true;
        }

        private bool TryGetNextRequest(out Request request)
        {
            try
            {
                this.context = this.httpListener.GetContext();
                HttpListenerRequest httpRequest = this.context.Request;
                request = new Request(httpRequest);
                return true;
            }
            catch (Exception)
            {
                //TODO: output/log exception
                request = null;
                return false;
            }
        }
    }
}
