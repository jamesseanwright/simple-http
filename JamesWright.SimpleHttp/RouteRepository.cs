using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.SimpleHttp
{
    class RouteRepository
    {
        public Dictionary<string, Action<Request, Response>> Get { get; private set; }
        public Dictionary<string, Action<Request, Response>> Post { get; private set; }
        public Dictionary<string, Action<Request, Response>> Put { get; private set; }
        public Dictionary<string, Action<Request, Response>> Delete { get; private set; }

        public RouteRepository()
        {
            Get = new Dictionary<string, Action<Request, Response>>();
            Post = new Dictionary<string, Action<Request, Response>>();
            Put = new Dictionary<string, Action<Request, Response>>();
            Delete = new Dictionary<string, Action<Request, Response>>();
        }

        public Dictionary<string, Action<Request, Response>> GetRoutes(string method)
        {
            switch (method)
            {
                case Methods.Get:
                    return Get;
                case Methods.Post:
                    return Post;
                case Methods.Put:
                    return Put;
                case Methods.Delete:
                    return Delete;
                default:
                    return null;
            }
        }
    }
}
