using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace JamesWright.SimpleHttp
{
    public class Request
    {
        private HttpListenerRequest httpRequest;

        internal Request(HttpListenerRequest httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        public string[] Parameters { get; private set; }

        public string Endpoint
        {
            get { return this.httpRequest.RawUrl; }
        }

        public string Method
        {
            get { return this.httpRequest.HttpMethod; }
        }

        public string Body
        {
            get
            {
                //TODO: handle exceptions
                if (Method == Methods.Get || !this.httpRequest.HasEntityBody)
                    return null;

                byte[] buffer = new byte[this.httpRequest.ContentLength64];
                this.httpRequest.InputStream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer);
            }
        }
    }
}
