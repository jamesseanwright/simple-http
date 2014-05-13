using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace JamesWright.SimpleHttp
{
    public class Request
    {
        private HttpListenerRequest httpRequest;

        public Request(HttpListenerRequest httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        public string[] Parameters { get; private set; }

        public string Endpoint
        {
            get { return this.httpRequest.RawUrl; }
        }
    }
}
