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

        public void Start(string port, Dictionary<string, Action<Request, Response>> routes)
        {
            this.httpListener.Prefixes.Add(string.Format("http://localhost:{0}/", port));
            this.httpListener.Start();

            Console.WriteLine("Listening for requests on port {0}.", port);

            Request request;

            while(GetNextRequest(out request))
            {
                Console.WriteLine("{0}: {1}", DateTime.Now, request.Endpoint);
                
                if (!TryRespond(request, routes))
                    Console.WriteLine("No handler specified for endpoint {0}.", request.Endpoint);
            }
        }

        private bool TryRespond(Request request, Dictionary<string, Action<Request, Response>> routes)
        {
            if (!routes.ContainsKey(request.Endpoint))
                return false;

            routes[request.Endpoint](request, new Response(context.Response));
            return true;
        }

        private bool GetNextRequest(out Request request)
        {
            try
            {
                context = this.httpListener.GetContext();
                HttpListenerRequest httpRequest = context.Request;
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
